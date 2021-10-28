using api.Controllers.Request;
using api.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace api.Repository.General
{
    public class ProductTypeRepository
    {
        string constr = "";
        public ProductTypeRepository()
        {
            this.constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        }

        public Dictionary<string, List<object>> getProductTypeList(Dictionary<string, object> dic, out long totalNumber)
        {
            Dictionary<string, List<object>> dictionary = new Dictionary<string, List<object>>();
            totalNumber = 0;
            List<object> list = new List<object>();
            try
            {
                DataSet ds = new DataSet();
                ds = ClsGeneral.GetDataSet("sp_GetProductType", dic);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var result = new
                    {
                        ProductType_ID = Convert.ToInt32(row["ProductType_ID"]),
                        ProductType_Code = Convert.ToString(row["ProductType_Code"]),
                        Description = Convert.ToString(row["Description"]),
                        Company_ID = Convert.ToString(row["Company_ID"]),
                        Branch_ID = Convert.ToString(row["Branch_ID"]),
                        Active = Convert.ToBoolean(row["Active"]),
                        Created_on = Convert.ToInt32(row["Created_on"]),
                        Modify_by = Convert.ToInt32(row["Modify_by"]),                       
                        Modify_on = Convert.ToString(row["Modify_on"]),
                    };

                    list.Add(result);
                }

                dictionary.Add("ProductTypeList", list);

                totalNumber = Convert.ToInt64(ds.Tables[0].Rows.Count.ToString());

                return dictionary;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Dictionary<string, object> find_ProductType_ByID(int productTypeID)
        {
            Dictionary<string, object> SingleProductType = new Dictionary<string, object>();

            List<object> list = new List<object>();
            try
            {
                DataTable dt = new DataTable();
                dt = ClsGeneral.GetDataTable("SELECT * FROM tblProductType WHERE ProductType_ID=" + productTypeID);
                foreach (DataRow row in dt.Rows)
                {
                    var result = new
                    {
                        ProductType_ID = Convert.ToInt32(row["ProductType_ID"]),
                        ProductType_Code = Convert.ToString(row["ProductType_Code"]),
                        Description = Convert.ToString(row["Description"]),
                        Company_ID = Convert.ToInt32(row["Company_ID"]),
                        Active = Convert.ToBoolean(row["active"]),
                        Created_on = Convert.ToString(row["created_on"]),
                        Created_by = Convert.ToInt32(row["created_by"]),
                        Modify_on = Convert.ToString(row["modify_on"]),
                        Modify_by = Convert.ToInt32(row["modify_by"]),                        
                    };

                    list.Add(result);
                }

                SingleProductType.Add("ProductType", list);

                return SingleProductType;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool delete_ProductType(int[] productTypeIds)
        {
            string SqlQuery = "";
            bool result = false;
            int EffectedRows = 0;
            try
            {
                SqlQuery = SqlQueryDeleteProductType(productTypeIds);
                if (SqlQuery != "")
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                    {
                        EffectedRows = ClsGeneral.ExcuteQuery(connection, SqlQuery);
                    }
                    if (EffectedRows > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return result;
        }

        public bool update_ProductType(ProductTypeRequest UserObject)
        {
            string SqlQuery = "";
            bool result = false;
            int EffectedRows = 0;
            try
            {
                SqlQuery = SqlQueryUpdateProductType(UserObject);
                if (SqlQuery != "")
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                    {
                        EffectedRows = ClsGeneral.ExcuteQuery(connection, SqlQuery);
                    }
                    if (EffectedRows > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return result;
        }

        public bool saveProductType(ProductTypeRequest UserObject)
        {
            string SqlQuery = "";
            bool result = false;
            int EffectedRows = 0;
            try
            {
                SqlQuery = SqlQueryInsertProductType(UserObject);
                if (SqlQuery != "")
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
                    {
                        EffectedRows = ClsGeneral.ExcuteQuery(connection, SqlQuery);
                    }
                    if (EffectedRows > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            return result;
        }

        private string SqlQueryUpdateProductType(ProductTypeRequest obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE [tblProductType] SET [ProductType_Code] = '{0}',[Description] = '{1}',[Company_ID] = {2} ", obj.ProductType_Code, obj.Description, obj.Company_ID);
            sb.AppendFormat(",[Active]={0},[Created_on]='{1}',[Created_by]={2},[Modify_on]= '{3}',[Modify_by]={4}", obj.Active, obj.Created_on, obj.Created_by, obj.Modify_on, obj.Modify_by);
            sb.AppendFormat("  WHERE ProductType_ID ={0}", obj.ProductType_ID);
            return sb.ToString();
        }

        private string SqlQueryInsertProductType(ProductTypeRequest obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO [tblProductType]([ProductType_Code],[Description],[Company_ID],[Active],[Created_on],[Created_by],[Modify_on],[Modify_by])");
            sb.AppendFormat(" VALUES ");
            sb.AppendFormat(" ('{0}','{1}',{2},{3} ", obj.ProductType_Code,obj.Description, obj.Company_ID, obj.Active);
            sb.AppendFormat(" ,'{0}',{1},'{2}',{3} )", obj.Created_on, obj.Created_by, obj.Modify_on, obj.Modify_by);
            return sb.ToString();
        }

        private string SqlQueryDeleteProductType(int[] productTypeIds)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int item in productTypeIds)
            {
                sb.AppendFormat("DELETE FROM tblProductType WHERE ProductType_ID={0}", item);
            }
            return sb.ToString();
        }
    }
}