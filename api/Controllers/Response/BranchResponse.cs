﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Response
{
    public class BranchResponse
    {
		private long _Branch_ID;

		[JsonProperty(PropertyName = "Branch_ID")]
		public long Branch_ID
		{
			get { return _Branch_ID; }
			set { _Branch_ID = value; }
		}

		private string _Branch_code;

		[JsonProperty(PropertyName = "Branch_code")]
		public string Branch_code
		{
			get { return _Branch_code; }
			set { _Branch_code = value; }
		}

		private string _Branch_name;

		[JsonProperty(PropertyName = "Branch_name")]
		public string Branch_name
		{
			get { return _Branch_name; }
			set { _Branch_name = value; }
		}

		private string _Address;

		[JsonProperty(PropertyName = "Address")]
		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
		}

		private long _Company_ID;

		[JsonProperty(PropertyName = "Company_ID")]
		public long Company_ID
		{
			get { return _Company_ID; }
			set { _Company_ID = value; }
		}

		private long _City_ID;

		[JsonProperty(PropertyName = "City_ID")]
		public long City_ID
		{
			get { return _City_ID; }
			set { _City_ID = value; }
		}

		private string _Phone;

		[JsonProperty(PropertyName = "Phone")]
		public string Phone
		{
			get { return _Phone; }
			set { _Phone = value; }
		}

		private string _Fax;

		[JsonProperty(PropertyName = "Fax")]
		public string Fax
		{
			get { return _Fax; }
			set { _Fax = value; }
		}

		private string _Email;

		[JsonProperty(PropertyName = "Email")]
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}

		private bool _Active;

		[JsonProperty(PropertyName = "Active")]
		public bool Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

		private DateTime _Created_on;

		[JsonProperty(PropertyName = "Created_on")]
		public DateTime Created_on
		{
			get { return _Created_on; }
			set { _Created_on = value; }
		}

		private long _Created_by;

		[JsonProperty(PropertyName = "Created_by")]
		public long Created_by
		{
			get { return _Created_by; }
			set { _Created_by = value; }
		}

		private DateTime _Modify_on;

		[JsonProperty(PropertyName = "Modify_on")]
		public DateTime Modify_on
		{
			get { return _Modify_on; }
			set { _Modify_on = value; }
		}

		private long _Modify_by;

		[JsonProperty(PropertyName = "Modify_by")]
		public long Modify_by
		{
			get { return _Modify_by; }
			set { _Modify_by = value; }
		}

		public BranchResponse()  { }
	}
}