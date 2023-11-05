using Dapper;
using FunksjonellProgrammering.Shared;
using FunksjonellProgrammering.Shared.Primitives;
using FunksjonellProgrammering.UserApi;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

SqlMapper.AddTypeHandler(new NameTypeHandler());
SqlMapper.AddTypeHandler(new RoleTypeHandler());

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<InitDb>();
// builder.Services.AddSingleton<FunkFunksjonellProgrammering.UserApiUser.IRepository, FunkFunksjonellProgrammering.UserApiUser.Repository>();
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

var create = Create.Configure(connectionString);
app.MapPost("/user", (User user)
    => create(user)
        .Match(
        Exception: _ => Results.Problem(),
        Success: _ => Results.Created($"/user/", user)
    ));

var read = Read.Configure(connectionString);
app.MapGet("/user/{id:int}", (int id)
    => read(id).Match(
        Exception: _ => Results.Problem(),
        Success: x => x.Match(
            None: () => Results.NotFound(),
            Some: Results.Ok
        )
    ));

app.Run();