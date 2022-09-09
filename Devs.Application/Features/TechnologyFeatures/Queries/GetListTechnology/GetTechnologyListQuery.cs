using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Devs.Application.Features.TechnologyFeatures.Dtos;
using Devs.Application.Features.TechnologyFeatures.Models;
using Devs.Application.Features.TechnologyFeatures.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Queries.GetListTechnology
{
    public class GetTechnologyListQuery:IRequest<TechnologyModelListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetTechnologyListQueryHandler : IRequestHandler<GetTechnologyListQuery, TechnologyModelListModel>
        {
            
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private TechnologyBusinessRules _technologyBusinessRules;

            public GetTechnologyListQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<TechnologyModelListModel> Handle(GetTechnologyListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> technologies = await _technologyRepository.GetListAsync(include: x=>x.Include(x=>x.ProgrammingLanguage),index: request.PageRequest.Page,size:request.PageRequest.PageSize);
                TechnologyModelListModel model = _mapper.Map<TechnologyModelListModel>(technologies);
                return model;
            }
        }
    }
}
