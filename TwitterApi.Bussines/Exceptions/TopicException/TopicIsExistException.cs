using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Exceptions.TopicException
{
    public class TopicIsExistException : Exception
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ExceptionMessage { get; set; }

        public TopicIsExistException()
        {
            ExceptionMessage = "Topic Already Add";
        }

        public TopicIsExistException(string? message)
        {
            ExceptionMessage = message;
        }
    }
}
