using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    public class PasswordChangeFailedException : Exception,IBaseException
    {

        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ExceptionMessage { get; set; }

        public PasswordChangeFailedException(string? message)
        {
            ExceptionMessage = message;
        }

        public PasswordChangeFailedException()
        {
            ExceptionMessage = "Password change failed. Please check the information you entered and try again.";
        }
    }
}
