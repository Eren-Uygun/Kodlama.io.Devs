using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserGitHubFeatures.Commands.CreateUserGitHub
{
    public class CreateUserGitHubCommandValidation:AbstractValidator<CreateUserGitHubCommand>
    {
        public CreateUserGitHubCommandValidation()
        {
            RuleFor(x=>x.UserId).NotEmpty();
            RuleFor(x=>x.UserId).NotNull();

            RuleFor(x=>x.GitHubUrl).NotNull();
            RuleFor(x=>x.GitHubUrl).NotEmpty();
        }
    }
}
