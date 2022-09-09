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

namespace Devs.Application.Features.TechnologyFeatures.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
          public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {

            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }
            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                var result = await _technologyRepository.GetAsync(x=>x.Id == request.Id);
                _technologyBusinessRules.CheckTechnologyWhenRequested(result);


                Technology mappedTechnology = _mapper.Map<Technology>(result);
                Technology updatedTechnology = _technologyRepository.Delete(mappedTechnology);
                DeletedTechnologyDto deletedTechnologyDto  = _mapper.Map<DeletedTechnologyDto>(updatedTechnology);

                return deletedTechnologyDto;
            }
        }
    }
}
