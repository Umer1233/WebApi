using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class ModuleType
    {
        private int module_type_ID;
        private string module_type_name;
        private bool active;
        public int Module_Type_ID { get { return module_type_ID; } set { module_type_ID = value; } }
        public string Module_Type_Name { get { return module_type_name; } set { module_type_name = value; } }
        public bool Active { get { return active; } set { active = value; } }
        public ModuleType() { }
    }
}