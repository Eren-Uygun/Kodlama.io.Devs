using Core.Application.Requests;
using Devs.Application.Features.ProgrammingLanguageFeatures.Commands.CreateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguageFeatures.Commands.DeleteProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguageFeatures.Commands.UpdateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguageFeatures.Dtos;
using Devs.Application.Features.ProgrammingLanguageFeatures.Models;
using Devs.Application.Features.ProgrammingLanguageFeatures.Queries.GetByIdProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguageFeatures.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("",result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
           await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]GetProgrammingLanguageByIdQuery getProgrammingLanguageByIdQuery)
        {
            GetProgrammingLanguageByIdDto getProgrammingLanguageByIdDto = await Mediator.Send(getProgrammingLanguageByIdQuery);
            return Ok(getProgrammingLanguageByIdDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetProgrammingLanguageListQuery getProgrammingLanguageListQuery = new() {PageRequest = pageRequest};
            ProgrammingLanguageListModel result = await Mediator.Send(getProgrammingLanguageListQuery);
            return Ok(result);
        }




    }
}
