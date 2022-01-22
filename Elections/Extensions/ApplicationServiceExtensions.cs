using Elections.Data;
using Elections.Interfaces;
using Elections.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Extensions
{
    static public class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => { // DbContext
                options.UseSqlServer(config.GetConnectionString("DefalutConnection"));
            });
            services.AddScoped<ITokenService, TokenService>(); // TokenService

            return services;
        }
    }
}
