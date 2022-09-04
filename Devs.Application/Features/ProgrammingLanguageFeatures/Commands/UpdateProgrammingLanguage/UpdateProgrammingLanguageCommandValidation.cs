using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageFeatures.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidation:AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidation()
        {
            RuleFor(x=>x.Id).NotNull();
            RuleFor(x=>x.Id).NotEmpty();

            RuleFor(x=>x.Name).NotNull();
            RuleFor(x=>x.Name).NotEmpty();
        }

    }
}
