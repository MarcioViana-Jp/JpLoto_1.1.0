using JpLoto.Application.Interfaces.Services;
using JpLoto.Data.Repositories;
using JpLoto.Domain.Interfaces.Services;
using JpLoto.Domain.Services;
using JpLoto.EmailServices;
using JpLoto.Identity.Data;
using JpLoto.Identity.Services;
using Microsoft.AspNetCore.Identity;

namespace JpLoto.Api.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("JpLotoConnection"), b => b.MigrationsAssembly("JpLoto.Api")));

            services.AddDbContext<IdentityDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("JpLotoConnection"), b => b.MigrationsAssembly("JpLoto.Api")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<ILoto6ResultRepository, Loto6ResultRepository>();
            services.AddScoped<ILoto7ResultRepository, Loto7ResultRepository>();
            services.AddScoped<IMiniLotoResultRepository, MiniLotoResultRepository>();

            services.AddScoped<ITrialService, TrialService>();
            services.AddScoped<ITrialRepository, TrialRepository>();

            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IPlanRepository, PlanRepository>();

            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ISubscriptionRepository, LicenseRepository>();

            services.AddSingleton<IEmailService, EmailService>();

        }
    }
}