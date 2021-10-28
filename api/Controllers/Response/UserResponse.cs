using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace api.Controllers.Response
{
    
    public class UserResponse
    {
        
        private int user_id;
        private string user_code;
        private string user_name;
        private string email_address;
        private string password;
        private bool isActive;
        private bool isAdmin;

        private int created_by;
        private int modify_by;
        private string created_on;
        private string modify_on;

        private int company_ID;
        private int branch_ID;
        private int role_id;

        [JsonProperty(PropertyName = "Branch_ID")]
        public int Branch_ID { get { return branch_ID; } set { branch_ID = value; } }

        [JsonProperty(PropertyName = "Company_ID")]
        public int Company_ID { get { return company_ID; } set { company_ID = value; } }

        [JsonProperty(PropertyName = "User_id")]
        public int User_id { get { return user_id; } set { user_id = value; } }

        [JsonProperty(PropertyName = "Role_id")]
        public int Role_id { get { return role_id; } set { role_id = value; } }


        [JsonProperty(PropertyName = "User_code")]
        public string User_code { get { return user_code; } set { user_code = value; } }
        [JsonProperty(PropertyName = "User_name")]
        public string User_name { get { return user_name; } set { user_name = value; } }

        [JsonProperty(PropertyName = "Email_address")]
        public string Email_address { get { return email_address; } set { email_address = value; } }
        [JsonProperty(PropertyName = "Password")]
        public string Password { get { return password; } set { password = value; } }

        [JsonProperty(PropertyName = "IsActive")]
        public bool IsActive { get { return isActive; } set { isActive = value; } }

        [JsonProperty(PropertyName = "isAdmin")]
        public bool IsAdmin { get { return isAdmin; } set { isAdmin = value; } }


        [JsonProperty(PropertyName = "Created_by")]
        public int Created_by { get { return created_by; } set { created_by = value; } }

        [JsonProperty(PropertyName = "Modify_by")]
        public int Modify_by { get { return modify_by; } set { modify_by = value; } }

        [JsonProperty(PropertyName = "Created_on")]
        public string Created_on { get { return created_on; } set { created_on = value; } }
        [JsonProperty(PropertyName = "Modify_on")]
        public string Modify_on { get { return modify_on; } set { modify_on = value; } }

        public UserResponse()  { }
    }

    public class UserResponseList
    {
        List<UserResponse> userList;

        [JsonProperty(PropertyName = "users")]
        public List<UserResponse> UserList
        {
            get
            {
                if (userList == null) userList = new List<UserResponse>();
                return userList;
            }
        }

        private int totalRows;

        [JsonProperty(PropertyName = "totalRows")]
        public int TotalRows { set { this.totalRows = value; } get { return totalRows; } }
        public UserResponseList() { }
    }
}