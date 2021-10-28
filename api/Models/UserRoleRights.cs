using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class UserRoleRights
    {
        public long User_Role_Rights_ID { get; set; }
        public long User_ID { get; set; }
        public long Menu_ID { get; set; }
        public long Action_Type_ID { get; set; }
    }
}