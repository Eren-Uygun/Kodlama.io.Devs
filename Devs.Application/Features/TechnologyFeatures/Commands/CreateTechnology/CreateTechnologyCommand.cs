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

namespace Devs.Application.Features.TechnologyFeatures.Commands.CreateTechnology
{
    public class CreateTechnologyCommand:IRequest<CreatedTechnologyDto>
    {
        public int ProgrammingLanguageId {get;set;}
        public string TechnologyName {get;set;}

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private TechnologyBusinessRules _technologyBusinessRules;

            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {

                await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.TechnologyName);

                _technologyBusinessRules.CheckProgrammingLanguageExistsWhenRequested(request.ProgrammingLanguageId);


                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology technology = await _technologyRepository.AddAsync(mappedTechnology);
                CreatedTechnologyDto createdTechnologyDto = _mapper.Map<CreatedTechnologyDto>(technology);


                return createdTechnologyDto;
            }
        }

    }
}
