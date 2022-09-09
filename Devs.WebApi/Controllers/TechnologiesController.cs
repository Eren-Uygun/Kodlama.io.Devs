using Core.Application.Requests;
using Devs.Application.Features.TechnologyFeatures.Commands.CreateTechnology;
using Devs.Application.Features.TechnologyFeatures.Commands.DeleteTechnology;
using Devs.Application.Features.TechnologyFeatures.Commands.UpdateTechnology;
using Devs.Application.Features.TechnologyFeatures.Dtos;
using Devs.Application.Features.TechnologyFeatures.Models;
using Devs.Application.Features.TechnologyFeatures.Queries.GetByIdTechnology;
using Devs.Application.Features.TechnologyFeatures.Queries.GetListTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreatedTechnologyDto createdTechnologyDto = await Mediator.Send(createTechnologyCommand);
            return Created("",createdTechnologyDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            UpdatedTechnologyDto updatedTechnologyDto = await Mediator.Send(updateTechnologyCommand); 
            return Ok(updatedTechnologyDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            DeletedTechnologyDto deletedTechnologyDto = await Mediator.Send(deleteTechnologyCommand);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetTechnologyByIdQuery getTechnologyByIdQuery)
        {
            GetTechnologyByIdDto getTechnologyByIdDto = await Mediator.Send(getTechnologyByIdQuery);
            return Ok(getTechnologyByIdDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetTechnologyListQuery getTechnologyListQuery = new() {PageRequest = pageRequest};
            TechnologyModelListModel technologyModelListModel = await Mediator.Send(getTechnologyListQuery);
            return Ok(technologyModelListModel);

        }
    }
}
