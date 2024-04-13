using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Bussines.Exceptions.Common
{
    public class NotFoundException<T> : Exception
        where T : BaseEntity
    {
        public NotFoundException() : base($"{typeof(T).Name} Not Found")
        {

        }

        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
