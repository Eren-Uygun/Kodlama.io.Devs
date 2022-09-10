using Core.Security.JWT;
using Devs.Application.Services.Repositories;
using Devs.Persistence.Context;
using Devs.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("KodlamaIoDevsConnectionString")));
            
            
            services.AddScoped<IProgrammingLanguageRepository,ProgrammingLanguageRepository>();
            services.AddScoped<ITechnologyRepository,TechnologyRepository>();
            services.AddScoped<IAppUserRepository,AppUserRepository>();
            services.AddScoped<IUserGitHubRepository,UserGitHubRepository>();


            return services;
        }
    }
}
