using Microsoft.Extensions.Logging;
using RiskManagementAppSharedUI.Services;
using RiskManagementAppSharedUI.Beans;
using Camera.MAUI;

namespace RiskManagementMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCameraView()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        builder.Services.AddOidcAuthentication(options =>
        {
            options.ProviderOptions.ClientId = "6S55zeHxJx05at2RPVza5yLUlMwFuNjI";
            options.ProviderOptions.Authority = "https://dev-3gzwd8uewkmypr7l.us.auth0.com";
            options.ProviderOptions.ResponseType = "code";
        });

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://505a-82-197-205-60.ngrok-free.app") });

        builder.Services.AddScoped<RiskService, RiskService>();
        builder.Services.AddScoped<CategoryService, CategoryService>();
        builder.Services.AddScoped<RiskHistoryService, RiskHistoryService>();
        builder.Services.AddScoped<ControlService, ControlService>();
        builder.Services.AddScoped<NormService, NormService>();

        builder.Services.AddSingleton<RiskBean, RiskBean>();
        builder.Services.AddSingleton<CategoryBean, CategoryBean>();
        builder.Services.AddSingleton<RiskHistoryBean, RiskHistoryBean>();
        builder.Services.AddSingleton<ControlBean, ControlBean>();
        builder.Services.AddSingleton<NormBean, NormBean>();

        return builder.Build();
    }
}