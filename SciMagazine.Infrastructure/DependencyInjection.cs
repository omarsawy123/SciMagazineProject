using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SciMagazine.Application.Interfaces.IServices;
using SciMagazine.Infrastructure.Data;
using SciMagazine.Infrastructure.Services;

namespace SciMagazine.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration config)
        {

            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.AddTransient<IEmailServices, EmailServices>();

            return services;
        }


    }
}
