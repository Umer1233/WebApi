using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class CompanyFlag : BaseModel
    {
        public long Company_Flag_ID { get; set; }
        public string Flag_Name { get; set; }
        public bool Active { get; set; }
        public long Company_ID { get; set; }
        public long Branch_ID { get; set; }
    }
}