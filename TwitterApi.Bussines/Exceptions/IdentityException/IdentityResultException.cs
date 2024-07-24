using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    public class IdentityResultException : Exception,IBaseException
    {


        public int StatusCode => StatusCodes.Status422UnprocessableEntity;

        public string ExceptionMessage { get; set; }

        public IdentityResultException(string? message)
        {
            ExceptionMessage = message;
        }
    }
}
