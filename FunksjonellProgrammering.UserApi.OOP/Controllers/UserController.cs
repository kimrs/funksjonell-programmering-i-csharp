using FunksjonellProgrammering.Shared.Primitives;
using FunksjonellProgrammering.UserApi.OOP.Repositories;
using LaYumba.Functional.Option;
using Microsoft.AspNetCore.Mvc;

namespace FunksjonellProgrammering.UserApi.OOP.Controllers
{
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
            => _userRepository.Read(id)
                .Match(
                    Exception: _ => Ok(),
                    Success: x => x.Match<IActionResult>(
                        None: NotFound,
                        Some: Ok
            ));

        [HttpPost]
        public IActionResult Create(User user)
            => _userRepository.Create(user)
                .Match(
                    Exception: _ => Problem(),
                    Success: _ => Created("/user/", user)
                );
    }
}