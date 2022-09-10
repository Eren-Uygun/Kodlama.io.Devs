using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Repositories
{
    public class UserGitHubRepository : EfRepositoryBase<UserGitHub, BaseDbContext>, IUserGitHubRepository
    {
        public UserGitHubRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
