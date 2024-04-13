namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    internal class AuthenticationErrorException : Exception
    {
        public AuthenticationErrorException() : base("Authentication Error")
        {

        }

        public AuthenticationErrorException(string message) : base(message)
        {

        }
    }
}
