using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Request
{
    public class LogInUserRequest
    {
        private string email;
        private string password;
        private int CompanyID;

        public int companyID { get { return CompanyID; } set { CompanyID = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }
    }
}