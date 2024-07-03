using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using TwitterApi.Bussines.Exceptions.IdentityException;
using TwitterApi.Bussines.ExternalContext.Interfaces;
using TwitterApi.Bussines.ExternalServices.Implements;
using TwitterApi.Bussines.ExternalServices.Interfaces;
using TwitterApi.Bussines.Helpers;

namespace TwitterApi.Api.Middlewares
{
    public static class TokenValidationMiddleware
    {        
        public static IApplicationBuilder UseTokenCheck(this WebApplication webApplication)
        {
            webApplication.Use(async (context,next) =>
            {
                using(var scope = context.RequestServices.CreateScope())
                {
                    var servic = scope.ServiceProvider.
                    GetRequiredService<IBlackListService>();
                    if (await servic.TokenCheckAsync(context.GetUserToken()))
                        throw new NotFoundUserException();
                }
                await next();
            });
            return webApplication;
        }
    }
}
