using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Module : BaseModel
    {
        public long Module_id { get; set; }
        public long Module_Type_ID { get; set; }
        public string Module_Name { get; set; }
        public bool Active { get; set; }
        public long Seq { get; set; }
    }
}