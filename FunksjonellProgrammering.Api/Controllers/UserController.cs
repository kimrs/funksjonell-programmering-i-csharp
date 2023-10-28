using FunksjonellProgrammering.Api.CreateUser;
using FunksjonellProgrammering.Api.GetUser;
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
        _createUser = createUser;
        _getUser = getUser;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _getUser.GetAll();
        return Ok(users.Select(u => u.ToDto()));
    }

    [HttpPost]
    public IActionResult Create(
        CreateUser.Domain user
    )
    {
        try
        {
            _createUser.Create(user);
            return Ok("User created");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
            return StatusCode(500);
        }
    }
}

