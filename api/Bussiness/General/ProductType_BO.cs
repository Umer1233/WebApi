using api.Controllers.Request;
using api.Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Bussiness.General
{
    public class ProductType_BO
    {
        public ProductType_BO() { }

        public string GetProductTypeList(Dictionary<string, object> dic)
        {
            try
            {
                long totalNumber;
                Dictionary<string, List<object>> dc = new Dictionary<string, List<object>>();

                ProductTypeRepository repo = new ProductTypeRepository();

                dc = repo.getProductTypeList(dic, out totalNumber);
                var oResult = new
                {
                    productType = dc["ProductTypeList"],
                    totalNumber = totalNumber
                };

                var ser = new System.Web.Script.Serialization.JavaScriptSerializer();
                ser.MaxJsonLength = Int32.MaxValue;

                return ser.Serialize(oResult);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string find_Product_Type_ByID(int productTypeID)
        {
            try
            {
                Dictionary<string, object> obj = new Dictionary<string, object>();

                ProductTypeRepository repo = new ProductTypeRepository();

                obj = repo.find_ProductType_ByID(productTypeID);
                var result = new
                {
                    productType = obj["ProductType"]
                };

                var ser = new System.Web.Script.Serialization.JavaScriptSerializer();
                ser.MaxJsonLength = Int32.MaxValue;

                return ser.Serialize(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool DeleteProductType(int[] productTypeIDs)
        {
            bool result = false;
            try
            {
                ProductTypeRepository repo = new ProductTypeRepository();
                result = repo.delete_ProductType(productTypeIDs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool update_product_type(ProductTypeRequest obj)
        {
            bool result = false;
            try
            {
                ProductTypeRepository repo = new ProductTypeRepository();
                result = repo.update_ProductType(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool SaveProductType(ProductTypeRequest obj)
        {
            bool result = false;
            try
            {
                ProductTypeRepository repo = new ProductTypeRepository();
                result = repo.saveProductType(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }



    }
}