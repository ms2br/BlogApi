namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    public class UserOrPassswordWrongException : Exception
    {
        public UserOrPassswordWrongException() : base("Username or Password is wrong")
        {
        }

        public UserOrPassswordWrongException(string? message) : base(message)
        {
        }
    }
}
