using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Menu : BaseModel
    {
		public long Menu_ID { get; set; }
		public string Menu_Name { get; set; }
		public string path { get; set; }
		public string component { get; set; }
		public string redirectTo { get; set; }
		public string pathMatch { get; set; }
		public string module { get; set; }
		public string childRoute { get; set; }
		public string MenuType { get; set; }
		public string breadCrums { get; set; }
		public long Menu_Category_ID { get; set; }
		public long Module_ID { get; set; }
		public bool Active { get; set; }
		public long Company_ID { get; set; }
		public long Branch_ID { get; set; }
		public long Seq { get; set; }
		public DateTime Created_on { get; set; }
		public long Created_by { get; set; }
		public DateTime Modify_on { get; set; }
		public long Modify_by { get; set; }

	}
}