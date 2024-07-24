using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Exceptions.PostReactionException
{
    public class PostReactionIsExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ExceptionMessage { get; set; }

        public PostReactionIsExistException(string message)
        {
            ExceptionMessage = message;    
        }

        public PostReactionIsExistException()
        {
            ExceptionMessage = "PostReaction Already Add";
        }
    }
}
