using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Exceptions.FileException
{
    public class InCorrectTypeException : Exception,IBaseException
    {

        public int StatusCode => StatusCodes.Status415UnsupportedMediaType;
        public string ExceptionMessage { get; set; }        

        public InCorrectTypeException(string? message)
        {
            ExceptionMessage = message;
        }

    }
}
