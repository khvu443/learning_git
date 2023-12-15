
using API.Common.Errors;
using API.Mapping;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, WebProblemDetailFactory>();

            services.ConfigureApplicationCookie(options =>
             {
                 options.Cookie.SameSite = SameSiteMode.None;
                 options.Cookie.SecurePolicy = CookieSecurePolicy.None;
             });

            services.ConfigCors();

            services.AddMappings();
            services.AddControllers();
            return services;
        }

        public static IServiceCollection ConfigCors(this IServiceCollection services)
        {
            services.AddCors(opts =>
            {
                opts.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder
                               .WithOrigins("http://localhost:5500")
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials();
                    });
            });
            return services;
        }

    }
}
