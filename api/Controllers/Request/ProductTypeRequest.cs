using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Request
{
    public class ProductTypeRequest
	{
		public long ProductType_ID { get; set; }
		public string ProductType_Code { get; set; }
		public string Description { get; set; }
		public long Company_ID { get; set; }
		public bool Active { get; set; }
		public DateTime Created_on { get; set; }
		public long Created_by { get; set; }
		public DateTime Modify_on { get; set; }
		public long Modify_by { get; set; }
	}
}