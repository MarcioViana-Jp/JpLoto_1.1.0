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
string[] allowedOrigins = {
    "https://localhost:7219", "http://localhost:5258",
    "https://v1-1.jploto.com","http://v1-1.jploto.com"
};

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "cors_policy",
                      policy =>
                      {
                          policy.WithOrigins(allowedOrigins)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.ConsentCookieValue = "true";
});

builder.Services.ApplicationSetup(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddApiProblemDetails();

builder.Services.AddLocalization(options => options.ResourcesPath = "SharedResource");
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(); //(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IoC
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddAuthorizationPolicies();

var app = builder.Build();

app.UseProblemDetails();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCookiePolicy();
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("cors_policy");

// Configure supported cultures
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(LocalizationSettings.SupportedCulturesCodes[0])
    .AddSupportedCultures(LocalizationSettings.SupportedCulturesCodes)
    .AddSupportedUICultures(LocalizationSettings.SupportedCulturesCodes);
app.UseRequestLocalization(localizationOptions);

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages().RequireCors("cors_policy");
app.MapControllers().RequireCors("cors_policy");
app.MapFallbackToFile("index.html");

app.Run();
