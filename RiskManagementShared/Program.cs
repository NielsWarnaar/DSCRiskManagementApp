using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RiskManagementShared.Services;
using RiskManagementShared;
using RiskManagementShared.Beans;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7023") });

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
