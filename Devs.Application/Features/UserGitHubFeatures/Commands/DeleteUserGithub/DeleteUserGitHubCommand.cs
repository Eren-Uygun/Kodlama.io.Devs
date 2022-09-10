using AutoMapper;
using Devs.Application.Features.ProgrammingLanguageFeatures.Dtos;
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

namespace Devs.Application.Features.UserGitHubFeatures.Commands.DeleteUserGithub
{
    public class DeleteUserGitHubCommand:IRequest<DeletedUserGitHubDto>
    {
       public int Id {get;set;}

        public class DeleteUserGitHubCommandHandler : IRequestHandler<DeleteUserGitHubCommand, DeletedUserGitHubDto>
        {
            private readonly IUserGitHubRepository _userGitHubRepository;
            private readonly IMapper _mapper;
            private readonly UserGitHubBusinessRules _userGitHubBusinessRules;

            public DeleteUserGitHubCommandHandler(IUserGitHubRepository userGitHubRepository, IMapper mapper, UserGitHubBusinessRules userGitHubBusinessRules)
            {
                _userGitHubRepository = userGitHubRepository;
                _mapper = mapper;
                _userGitHubBusinessRules = userGitHubBusinessRules;
            }

            public async Task<DeletedUserGitHubDto> Handle(DeleteUserGitHubCommand request, CancellationToken cancellationToken)
            {
               var result = await _userGitHubRepository.GetAsync(x=>x.Id == request.Id);

                UserGitHub mappedUserGitHub = _mapper.Map<UserGitHub>(result);
                UserGitHub deletedUserGitHub = await _userGitHubRepository.DeleteAsync(mappedUserGitHub);
                DeletedUserGitHubDto deletedUserGitHubDto = _mapper.Map<DeletedUserGitHubDto>(deletedUserGitHub);

                return deletedUserGitHubDto;
            }
        }
    }
}
