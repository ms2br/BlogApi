namespace TwitterApi.Bussines.Exceptions.TopicException
{
    public class TopicIsExistException : Exception
    {
        public TopicIsExistException() : base("Topic Already Add")
        {
        }

        public TopicIsExistException(string? message) : base(message)
        {
        }
    }
}
