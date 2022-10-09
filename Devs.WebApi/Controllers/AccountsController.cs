using Core.Security.Dtos;
using Core.Security.Entities;
using Devs.Application.Features.AuthFeatures.Commands.Login;
using Devs.Application.Features.AuthFeatures.Commands.Register;
using Devs.Application.Features.AuthFeatures.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {

            UserLoginCommand command = new() {UserForLoginDto = userForLoginDto};
            LoggingInDto result = await Mediator.Send(command);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("",result.AccessToken);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            UserRegisterCommand userRegisterCommand = new() { UserForRegisterDto = userForRegisterDto };
            RegisteredDto result = await Mediator.Send(userRegisterCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }


    }
}
