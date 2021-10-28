using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace api.Repository.General
{
    public class ProductBrandRepository
    {
        string constr = "";
        public ProductBrandRepository()
        {
            this.constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        }
    }
}