using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Response
{
    public class UserRoleRightsResponse
    {
		private long _User_Role_Rights_ID;

		[JsonProperty(PropertyName = "User_Role_Rights_ID")]
		public long User_Role_Rights_ID
		{
			get { return _User_Role_Rights_ID; }
			set { _User_Role_Rights_ID = value; }
		}

		private long _User_ID;
		[JsonProperty(PropertyName = "User_ID")]
		public long User_ID
		{
			get { return _User_ID; }
			set { _User_ID = value; }
		}

		private long _Menu_ID;

		[JsonProperty(PropertyName = "Menu_ID")]
		public long Menu_ID
		{
			get { return _Menu_ID; }
			set { _Menu_ID = value; }
		}

		private long _Action_Type_ID;

		[JsonProperty(PropertyName = "Action_Type_ID")]
		public long Action_Type_ID
		{
			get { return _Action_Type_ID; }
			set { _Action_Type_ID = value; }
		}

	}
}