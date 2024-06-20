using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Exceptions.IdentityException
{
    public class RoleCreateException:Exception
    {       
        public RoleCreateException(string message):base(message)
        {
            
        }
    }
}
