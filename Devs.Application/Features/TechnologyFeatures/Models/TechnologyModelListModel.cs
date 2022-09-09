using Devs.Application.Features.TechnologyFeatures.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.TechnologyFeatures.Models
{
    public class TechnologyModelListModel
    {
        public IList<GetTechnologyListDto> Items { get; set; }
    }
}
