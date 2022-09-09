using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommandValidation:AbstractValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyCommandValidation()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Id).NotNull();

        }
    }
}
