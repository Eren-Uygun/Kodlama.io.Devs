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

namespace Devs.Application.Features.TechnologyFeatures.Queries.GetByIdTechnology
{
    public class GetTechnologyByIdQuery:IRequest<GetTechnologyByIdDto>
    {
        public int Id { get; set; }

        public class GetTechnologyByIdQueryHandler : IRequestHandler<GetTechnologyByIdQuery, GetTechnologyByIdDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private TechnologyBusinessRules _technologyBusinessRules;

            public GetTechnologyByIdQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<GetTechnologyByIdDto> Handle(GetTechnologyByIdQuery request, CancellationToken cancellationToken)
            {
                Technology? technology = await _technologyRepository.GetAsync(x=>x.Id == request.Id);

                _technologyBusinessRules.CheckTechnologyWhenRequested(technology);

                GetTechnologyByIdDto getTechnologyByIdDto = _mapper.Map<GetTechnologyByIdDto>(technology);
                return getTechnologyByIdDto;


            }
        }

    }
}
