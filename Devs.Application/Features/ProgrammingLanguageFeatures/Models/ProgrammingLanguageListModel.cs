using Devs.Application.Features.ProgrammingLanguageFeatures.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.ProgrammingLanguageFeatures.Models
{
    public class ProgrammingLanguageListModel
    {
        public IList<GetProgrammingLanguageListDto> Items { get; set; }
    }
}
