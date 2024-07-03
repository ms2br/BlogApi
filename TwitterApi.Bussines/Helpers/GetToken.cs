using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Helpers
{
    public static class GetToken
    {
        public static string GetUserToken(this HttpContext httpContext)
        => httpContext.Request.
            Headers[HeaderNames.Authorization].ToString();
    }
}
