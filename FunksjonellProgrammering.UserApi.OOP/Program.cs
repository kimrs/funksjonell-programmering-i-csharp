global using LaYumba.Functional;
global using Unit = System.ValueTuple;
global using static LaYumba.Functional.F;

using Dapper;
using FunksjonellProgrammering.Shared;
using FunksjonellProgrammering.Shared.Primitives;
using FunksjonellProgrammering.UserApi.OOP;
using FunksjonellProgrammering.UserApi.OOP.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

SqlMapper.AddTypeHandler(new NameTypeHandler());
SqlMapper.AddTypeHandler(new RoleTypeHandler());

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<InitDb>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ConnectionString>();
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new PrimitiveConverter<Role, string>());
    options.SerializerOptions.Converters.Add(new PrimitiveConverter<Name, string>());
    options.SerializerOptions.Converters.Add(new PrimitiveConverter<UserId, int>());
});

builder.Services.AddControllers(o =>
{
    o.ModelBinderProviders.Insert(0, new UserIdModelBinderProvider());
})
.AddJsonOptions(o =>
{
    o.JsonSerializerOptions.Converters.Add(new PrimitiveConverter<Role, string>());
    o.JsonSerializerOptions.Converters.Add(new PrimitiveConverter<Name, string>());
    o.JsonSerializerOptions.Converters.Add(new PrimitiveConverter<UserId, int>());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<InitDb>();
    await context.Init();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var connectionString = app.Services.GetRequiredService<ConnectionString>();

// Func<UserId, Exceptional<Option<User>>> ConfigureRead(ConnectionString connectionString)
// => id =>
// {
//     try
//     {
//         return connectionString.Connect(c => c
//             .Query(Constants.ReadSql, new {Id = (int) id})
//             .Select(x => new User(x.Name, x.Role))
//             .Match(
//                 Empty: () => None,
//                 Otherwise: (user, _) => Some(user)
//             )
//         );
//     }
//     catch (Exception e)
//     {
//         return e;
//     }
// };
//
// var read = ConfigureRead(connectionString);
//
// app.MapGet("/user/{id:int}", (int id)
// => read(id)
//     .Match(
//         Exception: _ => Results.Problem(),
//         Success: u => u
//             .Match(
//                 None: () => Results.NotFound(),
//                 Some: Results.Ok
// )));
//
// Func<User, Exceptional<Unit>> ConfigureCreate(ConnectionString connectionString)
// => user =>
// {
//     try
//     {
//         connectionString.Connect(c => c.Execute(Constants.CreateSql, user));
//     }
//     catch (Exception e)
//     {
//         return e;
//     }
//
//     return Unit();
// };
//
// var create = ConfigureCreate(connectionString);
//
// app.MapPost("/user", (User user)
// => create(user)
//     .Match(
//         Exception: _ => Results.Problem(),
//         Success: _ => Results.Created("/user/", user)
// ));

app.Run();
