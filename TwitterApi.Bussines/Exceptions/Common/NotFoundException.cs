using Microsoft.AspNetCore.Http;
using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Bussines.Exceptions.Common
{
    public class NotFoundException<T> : Exception, IBaseException
        where T : class
    {

        public int StatusCode => StatusCodes.Status404NotFound;
        public string ExceptionMessage { get; set; }

        public NotFoundException()
        {
            ExceptionMessage = $"{typeof(T).Name} Not Found";
        }

        public NotFoundException(string? message)
        {
            ExceptionMessage = message;
        }
    }
}
