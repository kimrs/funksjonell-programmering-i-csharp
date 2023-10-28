using Microsoft.AspNetCore.Mvc;

namespace FunksjonellProgrammering.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly CreateUser.IRepository _createUser;
    private readonly GetUser.IRepository _getUser;

    public UserController(
        ILogger<UserController> logger,
        CreateUser.IRepository createUser,
        GetUser.IRepository getUser
    )
    {
        _logger = logger;
        _createUser = createUser;
        _getUser = getUser;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _getUser.GetAll();
        return Ok(users);
    }

    [HttpPost]
    public IActionResult Create(
        CreateUser.Domain user
    )
    {
        _createUser.Create(user);
        return Ok("User created");
    }
}

