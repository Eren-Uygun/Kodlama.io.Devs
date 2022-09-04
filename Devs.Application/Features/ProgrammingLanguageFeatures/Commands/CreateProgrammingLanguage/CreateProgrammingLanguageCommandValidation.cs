﻿using FluentValidation;
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
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c=>c.Name).NotNull();
        }
    }
}
