using System.Reactive;
using FunksjonellProgrammering.Api.Primitives;
using LaYumba.Functional;
using Microsoft.AspNetCore.Mvc;

namespace FunksjonellProgrammering.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly SqlTemplate _createUserSql = """
        INSERT INTO Users (Name, Role)
        VALUES (@Name, @Role)
    """;
    
    private readonly Func<CreateUser.Request, int> _createUser;
    private readonly GetUser.IRepository _getUser;

    public UserController(
        IConfiguration configuration,
        GetUser.IRepository getUser
    )
    {
         ConnectionString connectionString = configuration.GetConnectionString("ApiDb")
                            ?? throw new Exception("Connection string is missing");
         
         _createUser = connectionString.Save(_createUserSql);
    
        _getUser = getUser;
    }
    
    [HttpGet("{id:int}")]
    public IActionResult Get(
        UserId id
    )
    {
        var user = _getUser.Handle(id);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(
        CreateUser.Request user
    )
    {
        var id = _createUser(user);
        return Created($"/user/{id}", user);
    }
}

