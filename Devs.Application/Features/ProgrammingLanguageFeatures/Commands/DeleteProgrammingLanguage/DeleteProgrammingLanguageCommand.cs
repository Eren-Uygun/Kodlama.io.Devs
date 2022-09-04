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

namespace Devs.Application.Features.ProgrammingLanguageFeatures.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand:IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private IProgrammingLanguageRepository _programmingLanguageRepository;
            private IMapper _mapper;
            private ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var item = await _programmingLanguageRepository.GetAsync(x=>x.Id == request.Id);

                _programmingLanguageBusinessRules.checkProgrammingLanguageWhenRequested(item);
                ProgrammingLanguage result =  await _programmingLanguageRepository.DeleteAsync(item);
                DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(result);

                return deletedProgrammingLanguageDto;

                
            }
        }

    }
}
