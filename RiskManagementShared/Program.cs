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
builder.Services.AddSingleton<RiskBean, RiskBean>();
builder.Services.AddSingleton<CategoryBean, CategoryBean>();

await builder.Build().RunAsync();
