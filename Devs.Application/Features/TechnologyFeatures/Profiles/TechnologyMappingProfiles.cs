using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.TechnologyFeatures.Commands.CreateTechnology;
using Devs.Application.Features.TechnologyFeatures.Commands.DeleteTechnology;
using Devs.Application.Features.TechnologyFeatures.Commands.UpdateTechnology;
using Devs.Application.Features.TechnologyFeatures.Dtos;
using Devs.Application.Features.TechnologyFeatures.Models;
using Devs.Application.Features.TechnologyFeatures.Queries.GetByIdTechnology;
using Devs.Application.Features.TechnologyFeatures.Queries.GetListTechnology;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Profiles
{
    public class TechnologyMappingProfiles : Profile
    {
        public TechnologyMappingProfiles()
        {
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();

            CreateMap<Technology, GetTechnologyByIdDto>().ReverseMap();
            CreateMap<Technology, GetTechnologyByIdQuery>().ReverseMap();

            CreateMap<Technology, GetTechnologyListDto>().ForMember(x => x.ProgrammingLanguageName, opt =>opt.MapFrom(x =>x.ProgrammingLanguage.ProgrammingLanguageName)).ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyModelListModel>().ReverseMap();
            CreateMap<Technology, GetTechnologyListQuery>().ReverseMap();





        }
    }
}
