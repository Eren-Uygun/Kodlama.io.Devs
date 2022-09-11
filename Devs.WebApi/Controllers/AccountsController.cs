using Core.Security.Dtos;
using Devs.Application.Features.AuthFeatures.Commands.Login;
using Devs.Application.Features.AuthFeatures.Commands.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login ([FromBody]UserForLoginDto userForLoginDto)
        {
            var loginUserCommand = new UserLoginCommand { UserForLoginDto = userForLoginDto };
            var result = await Mediator.Send(loginUserCommand);
            return Ok("Giriş Yapıldı");
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            UserRegisterCommand userRegisterCommand = new() { UserForRegisterDto = userForRegisterDto  };
            var result = await Mediator.Send(userRegisterCommand);
            return Ok("Kayıt Yapıldı.");
        }


    }
}
