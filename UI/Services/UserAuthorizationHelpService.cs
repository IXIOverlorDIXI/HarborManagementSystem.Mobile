using System.Net.Http.Headers;
using System.Net.Http.Json;
using Domain.Dtos;
using IoC.Constants;
using Newtonsoft.Json.Linq;

namespace UI.Services
{
    public class UserAuthorizationHelpService
    {
        private readonly IServiceProvider _serviceProvider;
        private bool? isUserAuthenticated = null;
        private string settings = "";

        public bool? IsUserAuthenticated
        {
            get => isUserAuthenticated;
            set
            {
                if (isUserAuthenticated != value)
                {
                    isUserAuthenticated = value;
                    NotifyAuthenticationStateChanged();
                }
            }
        }

        public event Action AuthenticationStateChanged;

        private void NotifyAuthenticationStateChanged()
        {
            AuthenticationStateChanged?.Invoke();
        }

        public UserAuthorizationHelpService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public void Authorization() => IsUserAuthenticated = true;

        public void Logout() => IsUserAuthenticated = false;

        public async Task IsCredentialsRight()
        {
            string token = null;
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var localStorageService = scope.ServiceProvider.GetRequiredService<IStorageService>();
                    token = await localStorageService.GetAsync<string>(SavedDataSections.Token);
                }
            }
            catch (Exception e)
            {
                token = null;
            }

            if (token != null)
            {
                HttpResponseMessage response = default;
                using (var scope = _serviceProvider.CreateScope())
                {
                    var client = scope.ServiceProvider.GetRequiredService<HttpClient>();

                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

                    response = await client.GetAsync(ApiRoutes.Account.Controller);
                }
                

                var userDto = await response.Content.ReadFromJsonAsync<UserDto>();

                if (userDto != null)
                {
                    IsUserAuthenticated = true;
                    return;
                }
            }

            IsUserAuthenticated = false;
        }

        public async Task<string> GetSettings()
        {
            if (!string.IsNullOrEmpty(settings))
            {
                return settings;
            }

            if (isUserAuthenticated == null)
            {
                await IsCredentialsRight();
            }

            if (isUserAuthenticated ?? false)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var localStorageService = scope.ServiceProvider.GetRequiredService<IStorageService>();
                    var client = scope.ServiceProvider.GetRequiredService<HttpClient>();
                    
                    var token = await localStorageService.GetAsync<string>(SavedDataSections.Token);
                    
                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);

                        var response = await client.GetAsync(string.Concat(ApiRoutes.Account.Controller));
                    
                        var userDto = await response.Content.ReadFromJsonAsync<UserDto>();

                        if (userDto == null)
                        {
                            throw new Exception();
                        }
                    
                        response = await client.GetAsync(string.Concat(ApiRoutes.Profile.Settings, "?username=", userDto.Username));
                    
                        var settingsDto = await response.Content.ReadFromJsonAsync<SettingsDto>();

                        settings = settingsDto.Settings;

                        if (string.IsNullOrEmpty(settings))
                        {
                            settings = "{}";
                        }
                    }
                }
            }

            return settings;
        }

        public async Task SetLanguageSettings(string language)
        {
            if (string.IsNullOrEmpty(settings))
            {
                settings = "{}";
            }

            var settingsJson = JObject.Parse(settings);

            if (settingsJson.Properties().Any(x => x.Name.Equals("language")))
            {
                if (settingsJson["language"].Equals(language))
                {
                    return;
                }
            
                settingsJson.Remove("language");
            }
            
            settingsJson["language"] = language;

            settings = settingsJson.ToString();

            if (isUserAuthenticated == null)
            {
                await IsCredentialsRight();
            }

            if (isUserAuthenticated ?? false)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var localStorageService = scope.ServiceProvider.GetRequiredService<IStorageService>();
                    var client = scope.ServiceProvider.GetRequiredService<HttpClient>();

                    var token = await localStorageService.GetAsync<string>(SavedDataSections.Token);

                    if (token != null)
                    {
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);

                        var response = await client.PutAsJsonAsync(ApiRoutes.Profile.Settings, new SettingsDto{Settings = settings});
                    }
                }
            }
            
            settings = settingsJson.ToString();
        }
    }
}