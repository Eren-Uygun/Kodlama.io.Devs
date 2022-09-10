using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserGitHubFeatures.Commands.UpdateUserGitHub
{
    public class UpdateUserGitHubCommandValidation:AbstractValidator<UpdateUserGitHubCommand>
    {
        public UpdateUserGitHubCommandValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Id).NotNull();

            RuleFor(x=>x.AppUserId).NotNull();
            RuleFor(x=>x.AppUserId).NotEmpty();

            RuleFor(x=>x.GitHubUrl).NotEmpty();
            RuleFor(x=>x.GitHubUrl).NotNull();
        }
    }
}
