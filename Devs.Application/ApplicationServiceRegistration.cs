using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Devs.Application.Features.AuthFeatures.Rules;
using Devs.Application.Features.ProgrammingLanguageFeatures.Rules;
using Devs.Application.Features.TechnologyFeatures.Rules;
using Devs.Application.Features.UserGitHubFeatures.Rules;
using Devs.Application.Services.AuthService;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
           

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<TechnologyBusinessRules>();
            services.AddScoped<UserGitHubBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            /*
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            */

            services.AddScoped<IAuthService,AuthManager>();

            return services;

        }

    }
}
