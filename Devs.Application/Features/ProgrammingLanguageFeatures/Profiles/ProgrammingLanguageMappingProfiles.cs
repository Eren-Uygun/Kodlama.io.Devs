using AutoMapper;
using Core.Persistence.Paging;
using Devs.Application.Features.ProgrammingLanguageFeatures.Commands.CreateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguageFeatures.Commands.DeleteProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguageFeatures.Commands.UpdateProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguageFeatures.Dtos;
using Devs.Application.Features.ProgrammingLanguageFeatures.Models;
using Devs.Application.Features.ProgrammingLanguageFeatures.Queries.GetByIdProgrammingLanguage;
using Devs.Application.Features.ProgrammingLanguageFeatures.Queries.GetListProgrammingLanguage;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageFeatures.Profiles
{
    public class ProgrammingLanguageMappingProfiles : Profile
    {
        public ProgrammingLanguageMappingProfiles()
        {
            CreateMap<ProgrammingLanguage,CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage,CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage,UpdatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage,UpdateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage,DeletedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage,DeleteProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage,GetProgrammingLanguageListDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>,ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage,GetProgrammingLanguageListQuery>().ReverseMap();

            CreateMap<ProgrammingLanguage,GetProgrammingLanguageByIdDto>().ReverseMap();
            CreateMap<ProgrammingLanguage,GetProgrammingLanguageByIdQuery>().ReverseMap();


        }
    }
}
