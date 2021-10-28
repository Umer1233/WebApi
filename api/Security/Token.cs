using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Security
{
    public static class Token
    {
        public static string CreateToken(string email, string password)
        {
            string Token = Guid.NewGuid().ToString();
            return Token;
        }
    }
}