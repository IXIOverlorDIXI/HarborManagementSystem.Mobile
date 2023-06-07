using IoC.Configurations;
using IoC.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Maui.Devices;

namespace IoC.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, 
            IConfiguration configuration, 
            DevicePlatform platform, 
            HttpMessageHandler handler)
        {
            services.AddHttpClient("", client =>
            {
                var apiConfig = configuration
                    .GetSection(SectionNamesConstants.ApiSectionNameHttps)
                    .Get<ApiConfiguration>();
                client.BaseAddress = new Uri(platform.Equals(DevicePlatform.Android) 
                    ? "https://10.0.2.2:5000" 
                    : "https://localhost:5000");
            }).ConfigurePrimaryHttpMessageHandler(() => handler);
        }
    }
}