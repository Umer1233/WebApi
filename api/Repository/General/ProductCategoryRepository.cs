using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace api.Repository.General
{
    public class ProductCategoryRepository
    {
        string constr = "";
        public ProductCategoryRepository()
        {
            this.constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        }
    }
}