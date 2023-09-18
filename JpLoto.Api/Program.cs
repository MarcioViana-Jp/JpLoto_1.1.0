global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
using Hellang.Middleware.ProblemDetails;
using JpLoto.Api.Extensions;
using JpLoto.Api.IoC;
using JpLoto.EmailServices.Settings;
using Way2Commerce.Api.Extensions;

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
builder.Services.AddControllers();
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

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("cors_policy");

//app.UseCors(builder => builder
//    .SetIsOriginAllowed(orign => true)
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//    .AllowAnyMethod()
//    .AllowCredentials());

app.MapControllers();

app.Run();
