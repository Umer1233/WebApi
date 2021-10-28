using api.Bussiness.General;
using api.Controllers.Request;
using api.Controllers.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace api.Controllers.General
{
    public class ProductTypeController : ApiController
    {
        #region Constructor
        public ProductTypeController() { }

        #endregion

        #region Public Api Methods

        [ActionName("GetProductType")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetProductTypeList()
        {
            var queryString = (IEnumerable<KeyValuePair<string, string>>)Request.GetQueryNameValuePairs();
            return getProductTypeList(queryString);
        }
       
        [ActionName("GetProductTypeByID")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetProductTypeByID([FromUri] int user_id)
        {
            return getProductTypeByID(user_id);
        }

        [ActionName("DeleteProductType")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage DeleteProductType([FromUri] int[] UserIds)
        {
            return deleteProductType(UserIds);
        }

        [ActionName("UpdateProductType")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage UpdateProductType(ProductTypeRequest user)
        {
            return updateProductType(user);
        }

        [ActionName("SaveProductType")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage SaveProductType(ProductTypeRequest user)
        {
            return saveProductType(user);
        }

        #endregion

        #region Private Metods

        private HttpResponseMessage getProductTypeList(IEnumerable<KeyValuePair<string, string>> querystring)
        {
            try
            {
                int pageIndex = 1;
                int totalpages = 25;

                Dictionary<string, object> dic = new Dictionary<string, object>();

                dic.Add("pageIndex ", pageIndex);
                dic.Add("totalpages ", totalpages);

                foreach (KeyValuePair<string, string> item in querystring)
                {
                    if (item.Key.ToLower() == "product_type_code")
                    {
                        dic.Add("product_type_code", Convert.ToString(item.Value));
                    }
                    else if (item.Key.ToLower() == "product_type_id")
                    {
                        dic.Add("product_type_ids", Convert.ToString(item.Value));
                    }
                    else if (item.Key.ToLower() == "description")
                    {
                        dic.Add("description", Convert.ToString(item.Value));
                    }
                    else if (item.Key.ToLower() == "active")
                    {
                        dic.Add("active", Convert.ToBoolean(item.Value));
                    }
                    else if (item.Key.ToLower() == "branchID")
                    {
                        dic.Add("branchID", Convert.ToInt32(item.Value));
                    }
                }
                dic.Add("companyID", 1);                
                dic.Add("created_by", 1);

                ProductType_BO bo = new ProductType_BO();
                ProductTypeResponseList list = new ProductTypeResponseList();

                var result = bo.GetProductTypeList(dic);

                if (!String.IsNullOrEmpty(result))
                {
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);

                    foreach (dynamic item in json.users)
                    {
                        ProductTypeResponse obj = new ProductTypeResponse();
                        obj.ProductType_ID = Convert.ToInt32(item.ProductType_ID);
                        obj.ProductType_Code = Convert.ToString(item.ProductType_Code);
                        obj.Description = Convert.ToString(item.Description);
                        obj.Company_ID= Convert.ToInt32(item.Company_ID);
                        obj.Active = Convert.ToBoolean(item.Active);
                        obj.Created_by = Convert.ToInt32(item.Created_by);
                        obj.Modify_by = Convert.ToInt32(item.Modify_by);
                        obj.Created_on = Convert.ToString(item.Created_on);
                        obj.Modify_on = Convert.ToString(item.Modify_on);

                        list.ProductTypeList.Add(obj);
                    }

                    list.TotalRows = json.totalNumber;

                    return Request.CreateResponse(HttpStatusCode.OK, list);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No record found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong on server side please contact to system admin." + ex.Message.ToString());
            }
        }
     
        private HttpResponseMessage getProductTypeByID(int productTypeID)
        {
            try
            {
                ProductType_BO bo = new ProductType_BO();
                ProductTypeResponse obj = new ProductTypeResponse();

                var result = bo.find_Product_Type_ByID(productTypeID);

                if (!String.IsNullOrEmpty(result))
                {
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);

                    foreach (dynamic item in json.users)
                    {
                        obj = new ProductTypeResponse();
                        obj.ProductType_ID = Convert.ToInt32(item.ProductType_ID);
                        obj.ProductType_Code = Convert.ToString(item.ProductType_Code);
                        obj.Description = Convert.ToString(item.Description);                        
                        obj.Active = Convert.ToBoolean(item.Active);
                        obj.Created_by = Convert.ToInt32(item.Created_by);
                        obj.Modify_by = Convert.ToInt32(item.Modify_by);
                        obj.Created_on = Convert.ToString(item.Created_on);
                        obj.Modify_on = Convert.ToString(item.Modify_on);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, obj);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Record found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong on server side please contact to system admin." + ex.Message.ToString());
            }
        }

        private HttpResponseMessage deleteProductType(int[] productTypeIds)
        {            
            try
            {
                bool response = false;
                ProductType_BO bo = new ProductType_BO();
                response = bo.DeleteProductType(productTypeIds);

                if (response)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product type deleted successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Product type not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong on server side please contact to system admin." + ex.Message.ToString());
            }
        }

        private HttpResponseMessage updateProductType(ProductTypeRequest obj)
        {
            try
            {
                bool response = false;
                ProductType_BO bo = new ProductType_BO();
                response = bo.update_product_type(obj);

                if (response)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product type updated successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Product type not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong on server side please contact to system admin." + ex.Message.ToString());
            }
        }

        private HttpResponseMessage saveProductType(ProductTypeRequest obj)
        {
            try
            {
                bool response = false;
                ProductType_BO bo = new ProductType_BO();
                response = bo.SaveProductType(obj);

                if (response)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product Type created successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something wrong product type on creation, Please contach system admin");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong on server side please contact to system admin." + ex.Message.ToString());
            }
        }

        #endregion
    }
}