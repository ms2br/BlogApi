using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Exceptions.RedisException
{
    public class RedisMasterNameException : Exception
    {
        public RedisMasterNameException(string message) : base(message)
        {

        }
    }
}
