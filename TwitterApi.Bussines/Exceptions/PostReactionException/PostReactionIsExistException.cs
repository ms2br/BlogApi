using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Exceptions.PostReactionException
{
    public class PostReactionIsExistException : Exception
    {
        public PostReactionIsExistException(string message):base(message)
        {
            
        }

        public PostReactionIsExistException():base("PostReaction Already Add")
        {
            
        }
    }
}
