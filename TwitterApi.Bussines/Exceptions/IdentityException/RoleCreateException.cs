using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    public class RoleCreateException : Exception, IBaseException
    {


        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ExceptionMessage { get; set; }

        public RoleCreateException(string message)
        {
            ExceptionMessage = message;
        }
    }
}
