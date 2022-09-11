using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Services.Repositories
{
    public interface IUserRepository:IAsyncRepository<User>,IRepository<User>
    {
        public Task<User?> GetAsyncWithInclude(Expression<Func<User, bool>> predicate,Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null);
    }
}
