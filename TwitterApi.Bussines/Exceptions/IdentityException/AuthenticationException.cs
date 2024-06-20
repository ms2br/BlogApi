namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    internal class AuthenticationException : Exception
    {
        public AuthenticationException() : base("Authentication Error")
        {

        }

        public AuthenticationException(string message) : base(message)
        {

        }
    }
}
