using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using TwitterApi.Bussines.Exceptions;
using TwitterApi.Bussines.Exceptions.Common;

namespace TwitterApi.Api.Middlewares
{
    public static class CustomExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this WebApplication webApplication)
        {
            webApplication.UseExceptionHandler(async opt =>
            {
                opt.Run(async context =>
                {
                    IExceptionHandlerFeature? feature = context.Features
                .Get<IExceptionHandlerFeature>();
                    Exception excetion = feature.Error;

                    if (excetion is IBaseException ex)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = ex.StatusCode,
                            ExceptionMessage = ex.ExceptionMessage
                        });

                    }
                    else if (excetion is ArgumentNullException)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            ExceptionMessage = excetion.Message
                        });
                    }
                    else if (excetion is NullReferenceException)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            ExceptionMessage = excetion.Message
                        });
                    }
                    else if (excetion is ArgumentOutOfRangeException)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            ExceptionMessage = excetion.Message
                        });
                    }
                    else if (excetion is Exception)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {

                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = excetion.Message
                        });
                    }
                });
            });
            return webApplication;
        }
    }
}
