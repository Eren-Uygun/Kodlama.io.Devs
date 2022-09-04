using AutoMapper;
using Devs.Application.Features.ProgrammingLanguageFeatures.Dtos;
using Devs.Application.Features.ProgrammingLanguageFeatures.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageFeatures.Queries.GetByIdProgrammingLanguage
{
    public class GetProgrammingLanguageByIdQuery:IRequest<GetProgrammingLanguageByIdDto>
    {
        public int Id { get; set; }
        public class GetProgrammingLanguageByIdQueryHandler : IRequestHandler<GetProgrammingLanguageByIdQuery, GetProgrammingLanguageByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public GetProgrammingLanguageByIdQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<GetProgrammingLanguageByIdDto> Handle(GetProgrammingLanguageByIdQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(x=>x.Id == request.Id);

                _programmingLanguageBusinessRules.checkProgrammingLanguageWhenRequested(programmingLanguage);

                GetProgrammingLanguageByIdDto getProgrammingLanguageByIdDto = _mapper.Map<GetProgrammingLanguageByIdDto>(programmingLanguage);
                return getProgrammingLanguageByIdDto;
    
            }
        }

    }
}
