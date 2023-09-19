global using Microsoft.AspNetCore.Mvc;
using Hellang.Middleware.ProblemDetails;
using JpLoto.Api.Extensions;
using JpLoto.Api.IoC;
using JpLoto.EmailServices.Settings;
using JpLoto.Globalization.Localization.Constants;

var builder = WebApplication.CreateBuilder(args);

// Configure EmailServices
builder.Services.Configure<SmtpSetting>(builder.Configuration.GetSection("SMTP"));

// Add services to the container.
//builder.Services.AddCors();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "cors_policy",
//                      policy =>
//                      {
//                          policy.WithOrigins("https://localhost:7129", "http://localhost:5094")
//                          .AllowAnyMethod()
//                          .AllowAnyHeader();
//                      });
//});

builder.Services.AddCors(p => p.AddPolicy("cors_policy", policy =>
{
    policy.WithOrigins("https://localhost:7219")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddApiProblemDetails();
builder.Services.AddLocalization(options => options.ResourcesPath = "SharedResource");

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddRouting();
//builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IoC
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddAuthorizationPolicies();
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

//app.UseCors(builder => builder
//    .SetIsOriginAllowed(orign => true)
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//    .AllowAnyMethod()
//    .AllowCredentials());

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
