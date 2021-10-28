using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class MenuCategory : BaseModel
    {
        public long Menu_Category_ID { get; set; }
        public string MenuName { get; set; }
        public bool Active { get; set; }
        public long Company_ID { get; set; }
        public long Branch_ID { get; set; }
        public long Seq { get; set; }
        public System.DateTime Created_on { get; set; }
        public long Created_by { get; set; }
        public System.DateTime Modify_on { get; set; }
        public long Modify_by { get; set; }
    }
}