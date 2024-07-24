using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Exceptions.FileException
{
    public class InValidSizeException : Exception,IBaseException
    {

        public int StatusCode => StatusCodes.Status413PayloadTooLarge;
        public string ExceptionMessage { get; set; }

        public InValidSizeException(string message)
        {
            ExceptionMessage = message;
        }
    }
}
