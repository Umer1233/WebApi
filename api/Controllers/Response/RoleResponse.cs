using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Response
{
    public class RoleResponse
    {
		private long _Role_ID;

		[JsonProperty(PropertyName = "Role_ID")]
		public long Role_ID
		{
			get { return _Role_ID; }
			set { _Role_ID = value; }
		}

		private string _Role_Name;
		[JsonProperty(PropertyName = "Role_Name")]
		public string Role_Name
		{
			get { return _Role_Name; }
			set { _Role_Name = value; }
		}
	}
}