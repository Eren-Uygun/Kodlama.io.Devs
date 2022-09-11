using AutoMapper;
using Devs.Application.Features.UserGitHubFeatures.Dtos;
using Devs.Application.Features.UserGitHubFeatures.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserGitHubFeatures.Commands.CreateUserGitHub
{
    public class CreateUserGitHubCommand:IRequest<CreatedUserGitHubDto>
    {
        public int UserId {get;set;}
        public string GitHubUrl { get; set; }

        public class CreateUserGitHubCommandHandler : IRequestHandler<CreateUserGitHubCommand, CreatedUserGitHubDto>
        {
            private readonly IUserGitHubRepository _userGitHubRepository;
            private readonly IMapper _mapper;
            private readonly UserGitHubBusinessRules _userGitHubBusinessRules;

            public CreateUserGitHubCommandHandler(IUserGitHubRepository userGitHubRepository, IMapper mapper, UserGitHubBusinessRules userGitHubBusinessRules)
            {
                _userGitHubRepository = userGitHubRepository;
                _mapper = mapper;
                _userGitHubBusinessRules = userGitHubBusinessRules;
            }

            public async Task<CreatedUserGitHubDto> Handle(CreateUserGitHubCommand request, CancellationToken cancellationToken)
            {
                UserGitHub userGitHub = _mapper.Map<UserGitHub>(request);
                UserGitHub addedGithub = await _userGitHubRepository.AddAsync(userGitHub);
                CreatedUserGitHubDto createdUserGitHubDto = _mapper.Map<CreatedUserGitHubDto>(addedGithub);

                return createdUserGitHubDto;
            }
        }
    }
}
