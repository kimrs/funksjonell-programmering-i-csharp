using FunksjonellProgrammering.Shared.Primitives;
using FunksjonellProgrammering.UserApi.OOP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FunksjonellProgrammering.UserApi.OOP.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{id:int}")]
    public IActionResult Read(UserId id)
    {
        var user = _userRepository.Read(id);

        return user == null
            ? NotFound()
            : Ok(user);
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        _userRepository.Create(user);
        return Created("/user/", user);
    }
}