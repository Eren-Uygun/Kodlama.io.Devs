using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserGitHubFeatures.Rules
{
    public class UserGitHubBusinessRules
    {
        private readonly IUserGitHubRepository _userGitHubRepository;

        public UserGitHubBusinessRules(IUserGitHubRepository userGitHubRepository)
        {
            _userGitHubRepository = userGitHubRepository;
        }

        public async Task CheckUserGitHubUrlCanNotBeDuplicated(string gitHubUrl)
        {
            IPaginate<UserGitHub> userGitHub = await _userGitHubRepository.GetListAsync(x=>x.GitHubUrl == gitHubUrl);
            if(userGitHub==null) throw new BusinessException("User github url is exists");

        }

        public void CheckIsAppUserExists(User user)
        {
            if(user==null) throw new BusinessException("AppUser does not exists");
        }

        public void CheckIsUserGitHubExists(UserGitHub userGitHub)
        {
            if(userGitHub==null) throw new BusinessException("UserGitHub does not exists");
        }





    }
}
