using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TwitterApi.Bussines.Exceptions.IdentityException;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.Core.Enums;
using TwitterApi.DAL.Context;

namespace TwitterApi.Api.Middlewares
{
    public static class SeedMiddleware
    {
        public static IApplicationBuilder UseSeedData(this WebApplication webApplication)
        {
            webApplication.Use(async (context, next) =>
            {
                using (var scope = context.RequestServices.CreateScope())
                {
                   var um = scope.ServiceProvider
                    .GetRequiredService<UserManager<AppUser>>();      

                   var rm = scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();

                    if (!await rm.Roles.AnyAsync())
                        await CreateRolesAsync(rm);

                    string userName = webApplication.Configuration
                    .GetSection("Admin")["UserName"];

                    if (!await um.Users.AnyAsync(x =>
                    x.UserName == userName))
                    {

                        string password = webApplication.Configuration
                        .GetSection("Admin")["Password"];
                        await CreateUsersAsync(um, userName, password);
                    }
                }
                await next();
            });
            return webApplication;
        }

        public static async Task CreateRolesAsync(RoleManager<IdentityRole> rm)
        {
            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                var roleResult = await rm.
                  CreateAsync(new IdentityRole(role));
                if (!roleResult.Succeeded)
                {
                    StringBuilder roleErrors =
                    new StringBuilder();
                    foreach (var error in roleResult.Errors)
                    {
                        roleErrors
                        .Append(error.Description + " ");
                    }
                    throw new RoleCreateException(roleErrors.ToString().TrimEnd());
                }
            }
        }
        
        public static async Task CreateUsersAsync(UserManager<AppUser> um,string userName,string password)
        {
            AppUser appUser = new AppUser
            {
                UserName = userName,
                Email = userName + "@gmail.com",
                EmailConfirmed = true
            };
            var identityResult = await um.CreateAsync(appUser, password);
            if (!identityResult.Succeeded)
            {
                StringBuilder identityErrors = new StringBuilder();
                foreach (var error in identityResult.Errors)
                {
                    identityErrors.Append(error.Description + " ");
                }
                throw new IdentityResultException(identityErrors.ToString().TrimEnd());
            }

            var result = await um.
                AddToRoleAsync(appUser,nameof(Roles.Admin));

            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + " ");
                }
                throw new IdentityResultException(sb.ToString().TrimEnd());
            }
        }
    }
}
