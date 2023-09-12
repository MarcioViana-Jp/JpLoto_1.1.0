using Hellang.Middleware.ProblemDetails;
using JpLoto.Api.Extensions;
using JpLoto.Api.IoC;
using Way2Commerce.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
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
app.UseCors(builder => builder
    .SetIsOriginAllowed(orign => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.MapControllers();

app.Run();
