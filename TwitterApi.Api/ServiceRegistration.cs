using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.DAL.Context;

namespace TwitterApi.Api
{

    public class Jwt
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecurityKey { get; set; }
    }

    public static class ServiceRegistration
    {
        public static IServiceCollection AddUserIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = true;
                opt.SignIn.RequireConfirmedAccount = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredLength = 6;
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(3);
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<TwitterDbContext>()
                .AddDefaultTokenProviders(); ;
            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services,Jwt config)
        {
            services.AddAuthentication(
                scheme =>
                {
                    scheme.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    scheme.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    scheme.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,

                        ValidAudience = config.Audience,
                        ValidIssuer = config.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecurityKey)),
                        LifetimeValidator = (_, expires, securityToken, _) => expires != null ? expires >= DateTime.UtcNow : false
                    };
                });
            return services;
        }
    }
}
