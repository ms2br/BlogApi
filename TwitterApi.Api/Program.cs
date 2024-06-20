using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TwitterApi.Api;
using TwitterApi.Api.Middlewares;
using TwitterApi.Bussines;
using TwitterApi.Bussines.Helpers;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.DAL.Context;
using StackExchange.Redis;
using TwitterApi.Bussines.Dtos.RedisDtos;

var builder = WebApplication.CreateBuilder(args);
Jwt jwt = builder.Configuration.GetSection("Token").Get<Jwt>();

builder.Services.Configure<RedisOption>(builder.Configuration.GetSection("Redis"));
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
});
builder.Services.AddUserIdentity();
builder.Services.AddAuth(jwt);
builder.Services.AddAuthorization();
builder.Services.AddBusinessLayer();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSeedData();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

PathConstants.RootPath = builder.Environment.WebRootPath;

app.Run();
