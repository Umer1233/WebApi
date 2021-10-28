using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Branch : BaseModel
    {
        public long Branch_ID { get; set; }
        public string Branch_code { get; set; }
        public string Branch_name { get; set; }
        public string Address { get; set; }
        public long Company_ID { get; set; }
        public long City_ID { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public System.DateTime Created_on { get; set; }
        public long Created_by { get; set; }
        public System.DateTime Modify_on { get; set; }
        public long Modify_by { get; set; }
    }
}