namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException() : base("User Not Found")
        {

        }

        public NotFoundUserException(string message) : base(message)
        {

        }
    }
}
