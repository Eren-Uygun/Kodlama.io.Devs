using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class UserGitHub:Entity
    {
        public string GitHubUrl { get; set; }
    }
}
