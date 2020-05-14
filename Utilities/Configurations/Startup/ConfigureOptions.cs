using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Burak.Authorization.CommunicationEndpoints;

namespace Burak.Authorization.Api.Configurations.Startup
{
    public static class ConfigureOptions
    {
        public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CommunicationEndPoints>(options => configuration.GetSection(nameof(CommunicationEndPoints)).Bind(options));
            return services;
        }
    }
}
