using AutoMapper;
using Devs.Application.Features.UserGitHubFeatures.Commands.CreateUserGitHub;
using Devs.Application.Features.UserGitHubFeatures.Commands.DeleteUserGithub;
using Devs.Application.Features.UserGitHubFeatures.Commands.UpdateUserGitHub;
using Devs.Application.Features.UserGitHubFeatures.Dtos;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserGitHubFeatures.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserGitHub,CreateUserGitHubCommand>().ReverseMap();
            CreateMap<UserGitHub,CreatedUserGitHubDto>().ReverseMap();

            CreateMap<UserGitHub,UpdateUserGitHubCommand>().ReverseMap();
            CreateMap<UserGitHub,UpdatedUserGitHubDto>().ReverseMap();

            CreateMap<UserGitHub,DeleteUserGitHubCommand>().ReverseMap();
            CreateMap<UserGitHub,DeletedUserGitHubDto>().ReverseMap();


        }
    }
}
