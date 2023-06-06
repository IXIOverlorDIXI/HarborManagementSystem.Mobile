using IoC.Configurations;
using IoC.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IoC.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(Options.DefaultName, client =>
            {
                var apiConfig = configuration
                    .GetSection(SectionNamesConstants.ApiSectionNameHttps)
                    .Get<ApiConfiguration>();
                client.BaseAddress = new Uri("https://localhost:5000/");
            });
        }
    }
}