using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Exceptions.RedisException
{
    public class RedisMasterNameException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ExceptionMessage { get; set; }

        public RedisMasterNameException(string message)
        {
            ExceptionMessage = message;
        }
    }
}
