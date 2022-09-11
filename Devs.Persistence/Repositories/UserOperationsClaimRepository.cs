using Core.Persistence.Repositories;
using Core.Security.Entities;
using Devs.Application.Services.Repositories;
using Devs.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Repositories
{
    public class UserOperationsClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimsRepository
    {
        public UserOperationsClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
