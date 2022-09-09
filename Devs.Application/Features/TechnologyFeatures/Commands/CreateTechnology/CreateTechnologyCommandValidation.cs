using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidation : AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidation()
        {
            RuleFor(c => c.TechnologyName).NotEmpty();
            RuleFor(c => c.TechnologyName).NotNull();
        }
    }
}
