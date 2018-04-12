using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace LoansWebApi
{
    public static  class Userid
    {
        public static int getId(this IIdentity identity)
        {
            var c = ((ClaimsIdentity)identity).FindFirst("userID").Value;
            return Convert.ToInt16(c);

        }
    }
}