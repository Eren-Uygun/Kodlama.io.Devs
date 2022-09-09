using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Dtos
{
    public class GetTechnologyByIdDto
    {
        public int Id { get; set; }

        public string ProgrammingLanguageId { get; set; }
        public string TechnologyName { get; set; }
    }
}
