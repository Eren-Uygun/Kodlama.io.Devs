using Core.Persistence.Repositories;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using Devs.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence.Repositories
{
    public class AppUserRepository : EfRepositoryBase<AppUser, BaseDbContext>, IAppUserRepository
    {
        public AppUserRepository(BaseDbContext context) : base(context)
        {
            
        }

        public async Task<AppUser?> GetAsyncWithInclude(Expression<Func<AppUser, bool>> predicate, Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null)
        {
        IQueryable<AppUser> queryable = Query();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        return await queryable.FirstOrDefaultAsync();
        }
    }
}
