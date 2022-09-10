using AutoMapper;
using Core.Security.Dtos;
using Devs.Application.Features.AppUserFeatures.Commands.LoginAppUser;
using Devs.Application.Features.AppUserFeatures.Commands.RegisterAppUser;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.AppUserFeatures.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<AppUser,RegisterAppUserCommand>().ReverseMap();
            CreateMap<AppUser,LoginAppUserCommand>().ReverseMap();

            CreateMap<AppUser,UserForLoginDto>().ReverseMap();
            CreateMap<AppUser,UserForRegisterDto>().ReverseMap();
        }
    }
}
