using api.Bussiness;
using api.Controllers.Request;
using api.Controllers.Response;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using api.Security;
using System.Web.UI.WebControls;
//https://jacstech.wordpress.com/2013/08/20/passing-in-variables-to-custom-action-filters/
namespace api.Controllers
{
    public class LogInController : ApiController
    {
        
        //GET api/<controller>

        [ActionName("GetUsers")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetUsers()
        {
            var queryString = (IEnumerable<KeyValuePair<string, string>>)Request.GetQueryNameValuePairs();
            return getUserList(queryString);
        }

        [ActionName("GetToken")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage GenerateToken([FromUri] string email, [FromUri] string password)
        {            
            return Generatetoken(email, password);
        }

        [ActionName("login")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage LogIn(LogInUserRequest logIn)
        {
            return LogInUser(logIn);
        }

        [ActionName("GetUsersByID")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetUsersByID([FromUri] int user_id)
        {
            return findViewByID(user_id);
        }

        [ActionName("DeleteUsers")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage DeleteUser([FromUri] int[] UserIds)
        {
            return deleteUsers(UserIds);
        }

        [ActionName("UpdateUsers")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage UpdateUser(UserRequest user)
        {
            return updateUsers(user);
        }

        [ActionName("SaveUsers")]
        [AcceptVerbs("POST")]
        public HttpResponseMessage SaveUsers(UserRequest user)
        {
            return saveUsers(user);
        }



        private HttpResponseMessage Generatetoken(string email , string password) 
        {
            try
            {
                bool result = false;
                User_BO bo = new User_BO();
                string token = "";

                result = bo.GetUser(email, password);
                if (result)
                {
                    token  =Token.CreateToken(email, password);
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                else 
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong on server side please contact to system admin." + ex.Message.ToString());
            }
        }

        private HttpResponseMessage getUserList(IEnumerable<KeyValuePair<string, string>> querystring)
        {           
            try
            {
                int pageIndex = 1;
                int pageSize = 25;

                Dictionary<string, object> dic = new Dictionary<string, object>();

                dic.Add("pageIndex ", pageIndex);
                dic.Add("pageSize ", pageSize);

                foreach (KeyValuePair<string, string> item in querystring)
                {
                    if (item.Key.ToLower() == "user_id")
                    {
                        dic.Add("user_id ", Convert.ToString(item.Value));
                    }
                    else if (item.Key.ToLower() == "user_name")
                    {
                        dic.Add("user_name", Convert.ToString(item.Value));
                    }
                    else if (item.Key.ToLower() == "email_address")
                    {
                        dic.Add("email_address", Convert.ToString(item.Value));
                    }
                    else if (item.Key.ToLower() == "active")
                    {
                        dic.Add("active", Convert.ToBoolean(item.Value));
                    }
                }
                dic.Add("intCompanyID", 1);

                User_BO bo = new User_BO();
                UserResponseList list = new UserResponseList();

                var result = bo.GetUser(dic);

                if (!String.IsNullOrEmpty(result))
                {
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);

                    foreach (dynamic item in json.users)
                    {
                        UserResponse obj = new UserResponse();

                        obj.User_id = Convert.ToInt32(item.User_id);
                        obj.User_code = Convert.ToString(item.User_code);
                        obj.User_name = Convert.ToString(item.User_name);
                        obj.Email_address = Convert.ToString(item.Email_address);
                        obj.Password = Convert.ToString(item.Password);
                        obj.IsActive = Convert.ToBoolean(item.IsActive);
                        obj.Created_by = Convert.ToInt32(item.Created_by);
                        obj.Modify_by = Convert.ToInt32(item.Modify_by);
                        obj.Created_on = Convert.ToString(item.Created_on);
                        obj.Modify_on = Convert.ToString(item.Modify_on);

                        list.UserList.Add(obj);
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

        private HttpResponseMessage LogInUser(LogInUserRequest login)
        {
            try
            {

                LogInCompanyInfo logInResponse = new LogInCompanyInfo();
                CompanyResponse company = new CompanyResponse();
                BranchResponse branch = new BranchResponse();
                ModuleResponse module = new ModuleResponse();
                UserMenuResponse menu = new UserMenuResponse();
                UserMenuResponse UserMenutRoleRightsWise = new UserMenuResponse();
                UserRoleRightsResponse roleRights = new UserRoleRightsResponse();
                RoleResponse roleResponse = new RoleResponse();
                ActionTypeResponse actionTypeResponse = new ActionTypeResponse();
                

                Dictionary<string, object> param = new Dictionary<string, object>();

                User_BO bo = new User_BO();
                
                var result = bo.LogInUser(login);

                if (!String.IsNullOrEmpty(result))
                {
                    UserResponse obj = new UserResponse();

                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);

                    foreach (dynamic item in json.Users)
                    {
                        obj = new UserResponse();
                        obj.User_id = item.User_id;
                        obj.User_code = item.User_code;
                        obj.User_name = item.User_name;
                        obj.Email_address = item.Email_address;
                        obj.Password = item.Password;
                        obj.IsActive = item.IsActive;
                        obj.IsAdmin = item.IsAdmin;
                        obj.Role_id = item.Role_ID;
                        obj.Created_by = item.Created_by;
                        obj.Modify_by = item.Modify_by;
                        obj.Created_on = item.Created_on;
                        obj.Modify_on = item.Modify_on;
                        obj.Branch_ID = item.Branch_ID;
                        obj.Company_ID = item.Company_ID;
                    }

                    logInResponse.UserList.Add(obj);


                    if (obj.Company_ID != 0 && obj.Branch_ID != 0 && obj.User_id != 0)
                    {
                        param.Add("intCompanyID", obj.Company_ID);
                        param.Add("intBranchID", obj.Branch_ID);
                        param.Add("intUserID", obj.User_id);

                        var companyInfo = bo.GetLogInCompanyInformation(param);

                        if (!String.IsNullOrEmpty(companyInfo))
                        {
                            dynamic jsonCompany = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(companyInfo);

                            foreach (dynamic item in jsonCompany.Company)
                            {
                                company = new CompanyResponse();
                                company.Company_ID = item.Company_ID;
                                company.Company_code = item.Company_code;
                                company.Description = item.Description;
                                company.Address = item.Address;
                                company.City_ID = item.City_ID;
                                company.Phone = item.Phone;
                                company.Fax = item.Fax;
                                company.Email = item.Email;
                                company.Url = item.Url;
                                company.Ntnno = item.Ntnno;
                                company.Gstno = item.Gstno;
                                company.Active = item.Active;
                                company.Created_on = item.Created_on;
                                company.Created_by = item.Created_by;
                                company.Modify_on = item.Modify_on;
                                company.Modify_by = item.Modify_by;

                                logInResponse.CompanyList.Add(company);
                            }

                            foreach (dynamic item in jsonCompany.Branch)
                            {
                                branch = new BranchResponse();
                                branch.Branch_ID = item.Branch_ID;
                                branch.Company_ID = item.Company_ID;
                                branch.Branch_code = item.Branch_code;
                                branch.Branch_name = item.Branch_name;
                                branch.Address = item.Address;
                                branch.City_ID = item.City_ID;
                                branch.Phone = item.Phone;
                                branch.Fax = item.Fax;
                                branch.Email = item.Email;
                                branch.Active = item.Active;
                                branch.Created_on = item.Created_on;
                                branch.Created_by = item.Created_by;
                                branch.Modify_on = item.Modify_on;
                                branch.Modify_by = item.Modify_by;

                                logInResponse.BranchList.Add(branch);
                            }

                            foreach (dynamic item in jsonCompany.Module)
                            {
                                module = new ModuleResponse();
                                module.Module_id = item.Module_id;
                                module.Module_Name = item.Module_Name;
                                module.Module_Type_ID = item.Module_Type_ID;
                                module.Active = item.Active;

                                logInResponse.ModuleList.Add(module);
                            }

                            foreach (dynamic item in jsonCompany.menu)
                            {
                                menu = new UserMenuResponse();
                                menu.Menu_ID = item.Menu_ID;
                                menu.Menu_Name = item.Menu_Name;
                                menu.path = item.path;
                                menu.component = item.component;
                                menu.redirectTo = item.redirectTo;
                                menu.pathMatch = item.pathMatch;
                                menu.module = item.module;
                                menu.childRoute = item.childRoute;
                                menu.MenuType = item.MenuType;

                                menu.HaveSubMenu = item.HaveSubMenu;
                                menu.IsSubMenu = item.IsSubMenu;

                                menu.breadCrums = item.breadCrums;
                                menu.Menu_Category_ID = item.Menu_Category_ID;
                                menu.Module_ID = item.Module_ID;
                                menu.Company_ID = item.Company_ID;
                                menu.Branch_ID = item.Branch_ID;
                                menu.Seq = item.Seq;
                                menu.Active = item.Active;
                                menu.Created_on = item.Created_on;
                                menu.Created_by = item.Created_by;
                                menu.Modify_on = item.Modify_on;
                                menu.Modify_by = item.Modify_by;

                                logInResponse.MenuList.Add(menu);
                            }

                            foreach (dynamic item in jsonCompany.UserRoleRights)
                            {
                                roleRights = new UserRoleRightsResponse();
                                roleRights.User_Role_Rights_ID = item.User_Role_Rights_ID;
                                roleRights.User_ID = item.User_ID;
                                roleRights.Menu_ID = item.Menu_ID;
                                roleRights.Action_Type_ID = item.Action_Type_ID;

                                logInResponse.UserRoleRightsList.Add(roleRights);
                            }

                            //Menu
                            foreach (dynamic item in jsonCompany.UserMenuRoleRightWise)
                            {
                                UserMenutRoleRightsWise = new UserMenuResponse();

                                UserMenutRoleRightsWise.Menu_ID = item.Menu_ID;
                                UserMenutRoleRightsWise.Menu_Name = item.Menu_Name;
                                UserMenutRoleRightsWise.path = item.path;
                                UserMenutRoleRightsWise.component = item.component;
                                UserMenutRoleRightsWise.redirectTo = item.redirectTo;
                                UserMenutRoleRightsWise.pathMatch = item.pathMatch;
                                UserMenutRoleRightsWise.module = item.module;
                                UserMenutRoleRightsWise.childRoute = item.childRoute;
                                UserMenutRoleRightsWise.MenuType = item.MenuType;
                                UserMenutRoleRightsWise.HaveSubMenu = item.HaveSubMenu;
                                UserMenutRoleRightsWise.IsSubMenu = item.IsSubMenu;
                                UserMenutRoleRightsWise.breadCrums = item.breadCrums;
                                UserMenutRoleRightsWise.Menu_Category_ID = item.Menu_Category_ID;
                                UserMenutRoleRightsWise.Module_ID = item.Module_ID;
                                UserMenutRoleRightsWise.Company_ID = item.Company_ID;
                                UserMenutRoleRightsWise.Branch_ID = item.Branch_ID;
                                UserMenutRoleRightsWise.Seq = item.Seq;
                                UserMenutRoleRightsWise.Active = item.Active;
                                UserMenutRoleRightsWise.Created_on = item.Created_on;
                                UserMenutRoleRightsWise.Created_by = item.Created_by;
                                UserMenutRoleRightsWise.Modify_on = item.Modify_on;
                                UserMenutRoleRightsWise.Modify_by = item.Modify_by;

                                logInResponse.UserMenuRoleRightsList.Add(UserMenutRoleRightsWise);

                            }

                            foreach (dynamic item in jsonCompany.role)
                            {
                                roleResponse = new RoleResponse();

                                roleResponse.Role_ID = item.Role_ID;
                                roleResponse.Role_Name = item.Role_Name;

                                logInResponse.roleList.Add(roleResponse);
                            }

                            foreach (dynamic item in jsonCompany.actionType)
                            {
                                actionTypeResponse = new ActionTypeResponse();
                                actionTypeResponse.Action_Type_ID = item.Action_Type_ID;
                                actionTypeResponse.Action_Name = item.Action_Name;
                                logInResponse.actionTypeList.Add(actionTypeResponse);
                            }
                        }
                    }

                    //var resp = new HttpResponseMessage();
                    //var cookie = new CookieHeaderValue("session-id", "12345");
                    //cookie.Expires = DateTimeOffset.Now.AddDays(1);
                    //cookie.Domain = Request.RequestUri.Host;
                    //cookie.Path = "/";
                    //resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });

                    return Request.CreateResponse(HttpStatusCode.OK, logInResponse);
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


        private HttpResponseMessage findViewByID(int user_id)
        {         
            try
            {
                User_BO bo = new User_BO();
                UserResponse obj = new UserResponse();

                var result = bo.FindViewByID(user_id);

                if (!String.IsNullOrEmpty(result))
                {
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);

                    foreach (dynamic item in json.users)
                    {
                        obj = new UserResponse();
                        obj.User_id = Convert.ToInt32(item.User_id);
                        obj.User_code = Convert.ToString(item.User_code);
                        obj.User_name = Convert.ToString(item.User_name);
                        obj.Email_address = Convert.ToString(item.Email_address);
                        obj.Password = Convert.ToString(item.Password);
                        obj.IsActive = Convert.ToBoolean(item.IsActive);
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

        private HttpResponseMessage deleteUsers(int[] UserIds)
        {
            string[] message;
            try
            {
                bool response = false;
                User_BO bo = new User_BO();
                response = bo.DeleteUser(UserIds);

                if (response)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User deleted successfully");                    
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong on server side please contact to system admin." + ex.Message.ToString());
            }
        }

        private HttpResponseMessage updateUsers(UserRequest obj)
        {          
            try
            {
                bool response = false;
                User_BO bo = new User_BO();
                response = bo.UpdateUsers(obj);

                if (response)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User updated successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong on server side please contact to system admin." + ex.Message.ToString());
            }
        }

        private HttpResponseMessage saveUsers(UserRequest obj)
        {            
            try
            {
                bool response = false;
                User_BO bo = new User_BO();
                response = bo.SaveUsers(obj);

                if (response)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User created successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something wrong on user created please contach system admin");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Something wrong on server side please contact to system admin." + ex.Message.ToString());
            }
        }
    }
}
