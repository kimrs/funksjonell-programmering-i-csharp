using FunksjonellProgrammering.Api;
using FunksjonellProgrammering.Api.Primitives;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<InitDb>();
builder.Services.AddSingleton<FunksjonellProgrammering.Api.GetUser.IRepository, FunksjonellProgrammering.Api.GetUser.Repository>();
builder.Services.AddSingleton<FunksjonellProgrammering.Api.CreateUser.IRepository, FunksjonellProgrammering.Api.CreateUser.Repository>();
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


app.Run();
