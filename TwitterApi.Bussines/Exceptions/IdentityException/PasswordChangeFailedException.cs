namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    public class PasswordChangeFailedException : Exception
    {
        public PasswordChangeFailedException()
        {
        }

        public PasswordChangeFailedException(string? message) : base(message)
        {
        }
    }
}
