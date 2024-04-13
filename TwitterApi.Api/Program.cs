using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TwitterApi.Bussines;
using TwitterApi.Bussines.Helpers;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddDbContext<TwitterDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"));
})
    .AddIdentity<AppUser, IdentityRole>(opt =>
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
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),

            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires >= DateTime.UtcNow : false
        };
    });

builder.Services.AddBusinessLayer();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

PathConstants.RootPath = builder.Environment.WebRootPath;

app.Run();
