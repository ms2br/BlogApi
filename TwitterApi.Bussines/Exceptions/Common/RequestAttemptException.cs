using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Exceptions.Common
{
    public class RequestAttemptException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;
        public string ExceptionMessage { get; set; }

        public RequestAttemptException()
        {
            ExceptionMessage = "Failed Request Attempt";
        }

        public RequestAttemptException(string? message)
        {
            ExceptionMessage = message;
        }
    }
}
