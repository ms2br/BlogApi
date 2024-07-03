using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Exceptions.Common
{
    public class RequestAttemptException:Exception
    {
        public RequestAttemptException():base("Failed Request Attempt")
        {
            
        }

        public RequestAttemptException(string message):base(message)
        {
            
        }
    }
}
