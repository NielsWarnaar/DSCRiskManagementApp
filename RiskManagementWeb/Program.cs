using RiskManagementWeb;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RiskManagementAppSharedUI.Services;
using RiskManagementAppSharedUI.Shared;
using RiskManagementAppSharedUI.Beans;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5235") });

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

await builder.Build().RunAsync();
