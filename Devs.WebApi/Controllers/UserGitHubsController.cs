using Devs.Application.Features.UserGitHubFeatures.Commands.CreateUserGitHub;
using Devs.Application.Features.UserGitHubFeatures.Commands.DeleteUserGithub;
using Devs.Application.Features.UserGitHubFeatures.Commands.UpdateUserGitHub;
using Devs.Application.Features.UserGitHubFeatures.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGitHubsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserGitHubCommand createUserGitHubCommand)
        {
            CreatedUserGitHubDto createdUserGitHubDto = await Mediator.Send(createUserGitHubCommand);
            return Created("",createdUserGitHubDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserGitHubCommand updateUserGitHubCommand)
        {
            UpdatedUserGitHubDto updatedUserGitHubDto = await Mediator.Send(updateUserGitHubCommand);
            return Ok(updatedUserGitHubDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserGitHubCommand deleteUserGitHubCommand)
        {
            DeletedUserGitHubDto deletedUserGitHubDto = await Mediator.Send(deleteUserGitHubCommand);
            return Ok(deletedUserGitHubDto);
        }
    }
}
