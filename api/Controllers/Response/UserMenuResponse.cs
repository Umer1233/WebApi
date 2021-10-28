using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Response
{
    public class UserMenuResponse
    {
		private long _Menu_ID;

		[JsonProperty(PropertyName = "Menu_ID")]
		public long Menu_ID
		{
			get { return _Menu_ID; }
			set { _Menu_ID = value; }
		}

		private string _Menu_Name;

		[JsonProperty(PropertyName = "Menu_Name")]
		public string Menu_Name
		{
			get { return _Menu_Name; }
			set { _Menu_Name = value; }
		}


		private string _path;

		[JsonProperty(PropertyName = "path")]
		public string path
		{
			get { return _path; }
			set { _path = value; }
		}

		private string _component;

		[JsonProperty(PropertyName = "component")]
		public string component
		{
			get { return _component; }
			set { _component = value; }
		}

		private string _redirectTo;

		[JsonProperty(PropertyName = "redirectTo")]
		public string redirectTo
		{
			get { return _redirectTo; }
			set { _redirectTo = value; }
		}

		private string _pathMatch;
		[JsonProperty(PropertyName = "pathMatch")]
		public string pathMatch
		{
			get { return _pathMatch; }
			set { _pathMatch = value; }
		}

		private string _module;
		[JsonProperty(PropertyName = "module")]
		public string module
		{
			get { return _module; }
			set { _module = value; }
		}

		private string _childRoute;
		[JsonProperty(PropertyName = "childRoute")]
		public string childRoute
		{
			get { return _childRoute; }
			set { _childRoute = value; }
		}


		private string _breadCrums;

		[JsonProperty(PropertyName = "breadCrums")]
		public string breadCrums
		{
			get { return _breadCrums; }
			set { _breadCrums = value; }
		}

		private long _Menu_Category_ID;

		[JsonProperty(PropertyName = "Menu_Category_ID")]
		public long Menu_Category_ID
		{
			get { return _Menu_Category_ID; }
			set { _Menu_Category_ID = value; }
		}

		private long _Module_ID;

		[JsonProperty(PropertyName = "Module_ID")]
		public long Module_ID
		{
			get { return _Module_ID; }
			set { _Module_ID = value; }
		}

		private string _MenuType;

		[JsonProperty(PropertyName = "MenuType")]
		public string MenuType
		{
			get { return _MenuType; }
			set { _MenuType = value; }
		}

		private bool _Active;

		[JsonProperty(PropertyName = "Active")]
		public bool Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

		private bool _haveSubMenu;

		[JsonProperty(PropertyName = "haveSubMenu")]
		public bool HaveSubMenu
		{
			get { return _haveSubMenu; }
			set { _haveSubMenu = value; }
		}

		private bool _isSubMenu;

		[JsonProperty(PropertyName = "isSubMenu")]
		public bool IsSubMenu
		{
			get { return _isSubMenu; }
			set { _isSubMenu = value; }
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

		private long _Seq;

		[JsonProperty(PropertyName = "Seq")]
		public long Seq
		{
			get { return _Seq; }
			set { _Seq = value; }
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

		public UserMenuResponse()  { }
	}
}