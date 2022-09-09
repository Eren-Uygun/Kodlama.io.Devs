using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidation:AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).NotNull();

            RuleFor(x=>x.ProgrammingLanguageId).NotEmpty();
            RuleFor(x=>x.ProgrammingLanguageId).NotNull();

            

            RuleFor(x => x.TechnologyName).NotEmpty();
            RuleFor(x => x.TechnologyName).NotNull();
        }
    }
}
