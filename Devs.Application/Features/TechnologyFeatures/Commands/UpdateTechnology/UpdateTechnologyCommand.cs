using AutoMapper;
using Devs.Application.Features.TechnologyFeatures.Dtos;
using Devs.Application.Features.TechnologyFeatures.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand:IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId {get;set;}
        public string TechnologyName { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;
            

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
               

                _technologyBusinessRules.CheckTechnologyExistsWhenRequested(request.Id);
                _technologyBusinessRules.CheckProgrammingLanguageExistsWhenRequested(request.ProgrammingLanguageId);
                 await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.TechnologyName);
                

                var mappedTechnology = _mapper.Map<Technology>(request);
                var updatedTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);
                var updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);

                return updatedTechnologyDto;
            }
        }
    }
}
