using AutoMapper;
using Devs.Application.Features.TechnologyFeatures.Dtos;
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

namespace Devs.Application.Features.UserGitHubFeatures.Commands.UpdateUserGitHub
{
    public class UpdateUserGitHubCommand:IRequest<UpdatedUserGitHubDto>
    {
        public int Id { get; set; }
        public int UserId {get;set;}
        public string GitHubUrl { get; set; }

        public class UpdateUserGitHubCommandHandler : IRequestHandler<UpdateUserGitHubCommand, UpdatedUserGitHubDto>
        {
            private readonly IUserGitHubRepository _userGitHubRepository;
            private readonly IMapper _mapper;
            private readonly UserGitHubBusinessRules _userGitHubBusinessRules;

            public UpdateUserGitHubCommandHandler(IUserGitHubRepository userGitHubRepository, IMapper mapper, UserGitHubBusinessRules userGitHubBusinessRules)
            {
                _userGitHubRepository = userGitHubRepository;
                _mapper = mapper;
                _userGitHubBusinessRules = userGitHubBusinessRules;
            }

            public async Task<UpdatedUserGitHubDto> Handle(UpdateUserGitHubCommand request, CancellationToken cancellationToken)
            {
                var result = await _userGitHubRepository.GetAsync(x=>x.Id == request.Id);

                //await _userGitHubBusinessRules.CheckUserGitHubUrlCanNotBeDuplicated(request.GitHubUrl);
                _mapper.Map(request,result);
                UserGitHub updatedUserGitHub = await _userGitHubRepository.UpdateAsync(result);
                UpdatedUserGitHubDto updatedUserGitHubDto = _mapper.Map<UpdatedUserGitHubDto>(updatedUserGitHub);

                return updatedUserGitHubDto;
            }
        }
    }
}
