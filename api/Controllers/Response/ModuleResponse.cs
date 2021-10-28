using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Response
{
    public class ModuleResponse
    {
        private long _Module_id;

        [JsonProperty(PropertyName = "Module_id")]
        public long Module_id
        {
            get { return _Module_id; }
            set { _Module_id = value; }
        }

        private long _Module_Type_ID;

        [JsonProperty(PropertyName = "Module_Type_ID")]
        public long Module_Type_ID
        {
            get { return _Module_Type_ID; }
            set { _Module_Type_ID = value; }
        }

        private string _Module_Name;

        [JsonProperty(PropertyName = "Module_Name")]
        public string Module_Name
        {
            get { return _Module_Name; }
            set { _Module_Name = value; }
        }

        private bool _Active;

        [JsonProperty(PropertyName = "Active")]
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private long _Seq;

        [JsonProperty(PropertyName = "Seq")]
        public long Seq
        {
            get { return _Seq; }
            set { _Seq = value; }
        }

        public ModuleResponse()  { }
    }
}