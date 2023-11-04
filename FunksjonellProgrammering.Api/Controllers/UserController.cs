using System.Reactive;
using FunksjonellProgrammering.Api.CreateUser;
using FunksjonellProgrammering.Api.Primitives;
using LaYumba.Functional;
using Microsoft.AspNetCore.Mvc;

namespace FunksjonellProgrammering.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly Func<CreateUser.Request, int> _create;
    private readonly GetUser.IRepository _get;

    public UserController(
        IConfiguration configuration,
        GetUser.IRepository get
    )
    {
         _create = CreateHandler.Configure(configuration);
        _get = get;
    }
    
    [HttpGet("{id:int}")]
    public IActionResult Get(
        UserId id
    )
    {
        var user = _get.Handle(id);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(
        CreateUser.Request request
    ) => Created($"/user/{_create(request)}", request);
}