using Devs.Application.Features.UserGitHubFeatures.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserGitHubFeatures.Models
{
    public class UserGitHubModelList
    {
        public IList<ListUserGitHubDto> Items {get;set;}
    }
}
