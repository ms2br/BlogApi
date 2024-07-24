using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    public class UserOrPassswordWrongException : Exception, IBaseException
    {

        public int StatusCode => StatusCodes.Status401Unauthorized;

        public string ExceptionMessage { get; set; }
        public UserOrPassswordWrongException()
        {
            ExceptionMessage = "Username or Password is wrong";
        }

        public UserOrPassswordWrongException(string? message)
        {
            ExceptionMessage = message;
        }
    }
}
