using FunksjonellProgrammering.Shared.Primitives;
using LaYumba.Functional;
using LaYumba.Functional.Option;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Unit = System.ValueTuple;
using static LaYumba.Functional.F;

namespace FunksjonellProgrammering.UserApi.OOP.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly Func<UserId, Exceptional<Option<User>>> _read;
    private readonly Func<User, Exceptional<Unit>> _create;
    
    public UserController(
        ConnectionString connectionString
    )
    {
        _read = Read.Configure(connectionString);
        _create = Create.Configure(connectionString);
    }

    [HttpGet("{id:int}")]
    public IActionResult Read_(UserId id)
        => _read(id)
            .Match(
                Exception: _ => Ok(),
                Success: x => x.Match<IActionResult>(
                    None: NotFound,
                    Some: Ok
        ));

    [HttpPost]
    public IActionResult Create_(User user)
        => _create(user)
            .Match(
                Exception: _ => Problem(),
                Success: _ => Created("/user/", user)
            );
}