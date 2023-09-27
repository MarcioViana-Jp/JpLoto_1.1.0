global using JpLoto.Application.Dto;
global using JpLoto.Application.Dto.Request;
global using JpLoto.Application.Dto.Response;
global using JpLoto.Application.Interfaces;
global using JpLoto.Application.Services;
global using JpLoto.Application.Settings;
global using JpLoto.Data.JplContext;
global using JpLoto.Data.Repositories;
global using JpLoto.Domain.Entities;
global using JpLoto.Domain.Interfaces.Repositories;
global using JpLoto.Domain.Interfaces.Services;
global using JpLoto.Domain.Services;
global using JpLoto.Globalization.Localization.Constants;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
using Hellang.Middleware.ProblemDetails;
using JpLoto.Api.Extensions;
using JpLoto.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

var cors =
// Add services to the container.
builder.Services.AddCors(p => p.AddPolicy("cors_policy", policy =>
{
    //policy.WithOrigins("https://localhost:7219")
    policy.WithOrigins(builder.Configuration.GetValue<string>("JplCors:AllowedOrigins"))
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddApiProblemDetails();
builder.Services.AddLocalization(options => options.ResourcesPath = "SharedResource");

builder.Services.AddRazorPages();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.ConsentCookieValue = "true";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRouting();
//builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IoC
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddAuthorizationPolicies();
builder.Services.ApplicationSetup(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.UseProblemDetails();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();

// Configure supported cultures
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(LocalizationSettings.SupportedCulturesCodes[0])
    .AddSupportedCultures(LocalizationSettings.SupportedCulturesCodes)
    .AddSupportedUICultures(LocalizationSettings.SupportedCulturesCodes);

app.UseRequestLocalization(localizationOptions);

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("cors_policy");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
