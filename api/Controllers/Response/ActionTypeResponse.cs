using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Response
{
    public class ActionTypeResponse
    {
		private long _Action_Type_ID;

		public long Action_Type_ID
		{
			get { return _Action_Type_ID; }
			set { _Action_Type_ID = value; }
		}

		private string _Action_Name;

		public string Action_Name
		{
			get { return _Action_Name; }
			set { _Action_Name = value; }
		}

	}
}