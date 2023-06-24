using Microsoft.Extensions.Logging;
using RiskManagementAppSharedUI.Services;

namespace RiskManagementMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7023") });
        builder.Services.AddScoped<RiskService>();
        builder.Services.AddScoped<CategoryService>();
        builder.Services.AddScoped<RiskHistoryService>();
        builder.Services.AddScoped<ControlService>();
        builder.Services.AddScoped<NormService>();

        return builder.Build();
    }
}