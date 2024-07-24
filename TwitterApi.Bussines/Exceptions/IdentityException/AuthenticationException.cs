using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    internal class AuthenticationException : Exception, IBaseException
    {

        public int StatusCode => StatusCodes.Status401Unauthorized;
        public string ExceptionMessage { get; set; }

        public AuthenticationException()
        {
            ExceptionMessage = "Authentication Error";
        }

        public AuthenticationException(string message)
        {
            ExceptionMessage = message;
        }
    }
}
