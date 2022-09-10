using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserGitHubFeatures.Commands.DeleteUserGithub
{
    public class DeleteUserGitHubCommandValidation:AbstractValidator<DeleteUserGitHubCommand>
    {
        public DeleteUserGitHubCommandValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Id).NotNull();
        }
    }
}
