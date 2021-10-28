using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Response
{
    public class ProductTypeResponse
    {
		private long _ProductType_ID;

		[JsonProperty(PropertyName = "productType_ID")]
		public long ProductType_ID
		{
			get { return _ProductType_ID; }
			set { _ProductType_ID = value; }
		}

		private string _ProductType_Code;

		[JsonProperty(PropertyName = "productType_Code")]
		public string ProductType_Code
		{
			get { return _ProductType_Code; }
			set { _ProductType_Code = value; }
		}

		private string _Description;

		[JsonProperty(PropertyName = "description")]
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		private long _Company_ID;

		[JsonProperty(PropertyName = "company_ID")]
		public long Company_ID
		{
			get { return _Company_ID; }
			set { _Company_ID = value; }
		}

		private bool _Active;

		[JsonProperty(PropertyName = "active")]
		public bool Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

		private DateTime _Created_on;

		[JsonProperty(PropertyName = "created_on")]
		public DateTime Created_on
		{
			get { return _Created_on; }
			set { _Created_on = value; }
		}

		private long _Created_by;

		[JsonProperty(PropertyName = "created_by")]
		public long Created_by
		{
			get { return _Created_by; }
			set { _Created_by = value; }
		}

		private DateTime _Modify_on;

		[JsonProperty(PropertyName = "modify_on")]
		public DateTime Modify_on
		{
			get { return _Modify_on; }
			set { _Modify_on = value; }
		}

		private long _Modify_by;

		[JsonProperty(PropertyName = "modify_by")]
		public long Modify_by
		{
			get { return _Modify_by; }
			set { _Modify_by = value; }
		}

        public ProductTypeResponse() { }
	}

	public class ProductTypeResponseList
	{
		List<ProductTypeResponse> productTypeList;

		[JsonProperty(PropertyName = "productTypeList")]
		public List<ProductTypeResponse> ProductTypeList
		{
			get
			{
				if (productTypeList == null) productTypeList = new List<ProductTypeResponse>();
				return productTypeList;
			}
		}

		private int totalRows;

		[JsonProperty(PropertyName = "totalRows")]
		public int TotalRows { set { this.totalRows = value; } get { return totalRows; } }
		public ProductTypeResponseList() { }
	}
}