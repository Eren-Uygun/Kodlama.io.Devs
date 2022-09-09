using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Dtos
{
    public class UpdatedTechnologyDto
    {
        public int Id {get;set;}
        public int ProgrammingLanguageId { get; set; }
        public string TechnologyName { get; set; }
    }
}
