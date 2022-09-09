using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageFeatures.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandValidation : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommandValidation()
        {
            RuleFor(c => c.ProgrammingLanguageName).NotEmpty();
            RuleFor(c=>c.ProgrammingLanguageName).NotNull();
        }
    }
}
