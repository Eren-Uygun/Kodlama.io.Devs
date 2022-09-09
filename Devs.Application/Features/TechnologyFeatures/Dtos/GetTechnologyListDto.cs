using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Dtos
{
    public class GetTechnologyListDto
    {
        public int Id { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public string TechnologyName { get; set; }
    }
}
