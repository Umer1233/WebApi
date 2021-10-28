using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class User : BaseModel
    {
        private int user_id;
        private string user_code;
        private string user_name;
        private string email_address;
        private string password;
        private int isActive;
        private int created_by;
        private int modify_by;
        private DateTime created_on;
        private DateTime modify_on;

        private int CompanyID;

        public int User_id { get { return user_id; } set { user_id = value; } }
        public string User_code { get { return user_code; } set { user_code = value; } }
        public string User_name { get { return user_name; } set { user_name = value; } }
        public string Email_address { get { return email_address; } set { email_address = value; } }
        public string Password { get { return password; } set { password = value; } }
        public int IsActive { get { return isActive; } set { isActive = value; } }

        public int Created_by { get { return created_by; } set { created_by = value; } }
        public int Modify_by { get { return modify_by; } set { modify_by = value; } }

        public DateTime Created_on { get { return created_on; } set { created_on = value; } }
        public DateTime Modify_on { get { return modify_on; } set { modify_on = value; } }
        public int companyID { get { return CompanyID; } set { CompanyID = value; } }
        public User() { }
    }
}