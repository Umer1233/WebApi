using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Response
{
    public class CompanyFlagResponse
    {        
		private long _Company_Flag_ID;

		[JsonProperty(PropertyName = "Company_Flag_ID")]
		public long Company_Flag_ID { get { return _Company_Flag_ID; } set { _Company_Flag_ID = value; } }

		private string _Flag_Name;
		[JsonProperty(PropertyName = "Flag_Name")]
		public string Flag_Name
		{
			get { return _Flag_Name; }
			set { _Flag_Name = value; }
		}

		private bool _Active;
		[JsonProperty(PropertyName = "Active")]
		public bool Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

		private string _Flag_Type;
		[JsonProperty(PropertyName = "Flag_Type")]
		public string Flag_Type
		{
			get { return _Flag_Type; }
			set { _Flag_Type = value; }
		}

		private long _Company_ID;
		[JsonProperty(PropertyName = "Company_ID")]
		public long Company_ID
		{
			get { return _Company_ID; }
			set { _Company_ID = value; }
		}

		private long _Branch_ID;

		[JsonProperty(PropertyName = "Branch_ID")]
		public long Branch_ID
		{
			get { return _Branch_ID; }
			set { _Branch_ID = value; }
		}

		public CompanyFlagResponse() { }
	}
}