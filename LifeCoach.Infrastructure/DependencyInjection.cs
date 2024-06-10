
using LifeCoach.Application;
using LifeCoach.Domain;
using LifeCoach.Infrastructure.Persistence.Contexts;
using LifeCoach.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Extensions;
using Resend;


namespace LifeCoach.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(
                container => container.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSettings>(jwtSettings => configuration.GetSection("JwtSettings").Bind(jwtSettings));

            services.AddIdentity<User, Role>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                    options.User.RequireUniqueEmail = true;



                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<IIdentityService, IdentityManager>();
            services.AddScoped<IEmailService, ResendEmailManager>();
            services.AddOpenAIService(settings=>settings.ApiKey = configuration.GetSection("OpenAIApiKey").Value!);


            services.AddScoped<IOpenAIService,OpenAIManager>();
            // Resend
            services.AddOptions();
            services.AddHttpClient<ResendClient>();
            // Sets the token lifesoan to 3 hours for email confirmation
            services.Configure<DataProtectionTokenProviderOptions>( o =>
            {
                o.TokenLifespan = TimeSpan.FromHours(3);
            } );
            services.Configure<ResendClientOptions>( o =>
            {
                o.ApiToken = configuration.GetSection("ReSendApiKey").Value!;
            } );
            services.AddTransient<IResend, ResendClient>();
            

            return services;
        }
    }
}