using Core.Persistence.Repositories;
using Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Services.Repositories
{
    public interface IAppUserRepository:IAsyncRepository<AppUser>,IRepository<AppUser>
    {
            public Task<AppUser?> GetAsyncWithInclude(Expression<Func<AppUser, bool>> predicate,Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null);
    }
}
