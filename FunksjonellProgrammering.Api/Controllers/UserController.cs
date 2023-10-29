using FunksjonellProgrammering.Api.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace FunksjonellProgrammering.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly CreateUser.IRepository _createUser;
    private readonly GetUser.IRepository _getUser;

    public UserController(
        CreateUser.IRepository createUser,
        GetUser.IRepository getUser
    )
    {
        _createUser = createUser;
        _getUser = getUser;
    }
    
    [HttpGet("{id:int}")]
    public IActionResult Get(
        UserId id
    )
    {
        var user = _getUser.Get(id);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(
        CreateUser.Domain user
    )
    {
        _createUser.Create(user);
        return Created("/user/", user);
    }
}

