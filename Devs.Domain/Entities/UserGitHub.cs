using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class UserGitHub:Entity
    {
        public int AppUserId {get;set;}
        public string GitHubUrl { get; set; }

        public virtual AppUser AppUser {get;set;}

        public UserGitHub()
        {

        }

        public UserGitHub(int id,int appUserId, string gitHubUrl):this()
        {
            Id = id;
            AppUserId = appUserId;
            GitHubUrl = gitHubUrl;
        }
    }
}
