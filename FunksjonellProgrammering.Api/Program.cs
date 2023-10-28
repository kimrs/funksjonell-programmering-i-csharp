using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using FunksjonellProgrammering.Api;
using FunksjonellProgrammering.Api.Primitives;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<InitDb>();
builder.Services.AddSingleton<FunksjonellProgrammering.Api.GetUser.IRepository, FunksjonellProgrammering.Api.GetUser.Repository>();
builder.Services.AddSingleton<FunksjonellProgrammering.Api.CreateUser.IRepository, FunksjonellProgrammering.Api.CreateUser.Repository>();
builder.Services.AddControllers().AddJsonOptions(o =>
{
    // o.JsonSerializerOptions.Converters.Add(new NameConverter());
    o.JsonSerializerOptions.Converters.Add(new StringConverter<Name>());
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
