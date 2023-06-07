using System.Reflection;
using FluentValidation;
using IoC.Extensions;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using UI.Services;

namespace UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();
            
        builder.Services.AddMudServices();
        
        builder.Services.AddApplicationServices(builder.Configuration);
            
        builder.Services.AddLocalization();
            
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<UserAuthorizationHelpService>();
        builder.Services.AddSingleton<LocalizationService>();
        builder.Services.AddSingleton<IStorageService, StorageService>();
        
        return builder.Build();
    }
}