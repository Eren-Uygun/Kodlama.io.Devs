using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.UserGitHubFeatures.Dtos
{
    public class UpdatedUserGitHubDto
    {
        public int Id { get; set; }

        public int UserId {get;set;}
        public string GitHubUrl {get;set;}
    }
}
