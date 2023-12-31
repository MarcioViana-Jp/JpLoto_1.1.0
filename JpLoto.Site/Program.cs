global using Blazored.LocalStorage;
global using JpLoto.Data.Repositories;
global using JpLoto.Domain.Interfaces.Repositories;
global using JpLoto.Domain.Interfaces.Services;
global using JpLoto.Domain.Services;
global using JpLoto.Globalization.Localization;
global using JpLoto.Lottery.Dto;
global using JpLoto.Site;
global using JpLoto.Site.Dto;
global using JpLoto.Site.Interfaces.Repositories;
global using JpLoto.Site.Interfaces.Services;
global using JpLoto.Site.Services;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Components.Forms;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using Microsoft.JSInterop;
global using System.Globalization;
using JpLoto.Site.Extensions;
using JpLoto.Site.Providers;
using JpLoto.Site.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddLocalization();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAppConfigService, AppConfigService>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
builder.Services.AddScoped<ICheckoutService, CheckoutService>();
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<ILoto6ResultService, Loto6ResultService>();
builder.Services.AddScoped<ILoto7ResultService, Loto7ResultService>();
builder.Services.AddScoped<IMiniLotoResultService, MiniLotoResultService>();

builder.Services.AddScoped<ILoto6ResultRepository, Loto6ResultRepository>();
builder.Services.AddScoped<ILoto7ResultRepository, Loto7ResultRepository>();
builder.Services.AddScoped<IMiniLResultRepository, MiniLResultRepository>();
builder.Services.AddScoped<IMyProfileRepository, MyProfileRepository>();

builder.Services.AddSingleton<CommonLocalizationService>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

var host = builder.Build();
await host.SetDefaultCulture();
await host.RunAsync();

//await builder.Build().RunAsync();
