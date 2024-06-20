using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Dtos.RedisDtos
{
    public class RedisOption
    {
        public string[] Sentinels { get; set; }
        public string MasterName { get; set; }
    }
}
