using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SciMagazine.Infrastructure.Options;

namespace SciMagazine.Infrastructure
{
    public static class EmailConfiguration
    {
        public static IServiceCollection AddEmailConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<SendGridOptions>(options => config.GetSection("SendGrid"));

            return services;
        }
    }
}
