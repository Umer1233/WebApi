using api.Controllers.Request;
using api.Models;
using api.Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace api.Bussiness
{
    public class User_BO
    {
        public User_BO() { }


        public string GetUser(Dictionary<string, object> dic)
        {
            try
            {
                long totalNumber;
                Dictionary<string, List<object>> dc = new Dictionary<string, List<object>>();

                UserRepository repo = new UserRepository();

                dc = repo.GetUsersList(dic, out totalNumber);
                var oResult = new
                {
                    users = dc["Users"],
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

        public string FindViewByID(int user_id)
        {
            try
            {
                Dictionary<string, object> obj = new Dictionary<string, object>();

                UserRepository repo = new UserRepository();

                obj = repo.Find_View_By_ID(user_id);
                var result = new
                {
                    users = obj["Users"]
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
        public bool DeleteUser(int[] user_id)
        {
            bool result = false;
            try
            {
                UserRepository repo = new UserRepository();
                result = repo.DeleteUsers(user_id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool UpdateUsers(UserRequest obj)
        {
            bool result = false;
            try
            {
                UserRepository repo = new UserRepository();
                result = repo.UpdateUser(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool SaveUsers(UserRequest obj)
        {
            bool result = false;
            try
            {
                UserRepository repo = new UserRepository();
                result = repo.SaveUsers(obj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool GetUser(string email, string password) 
        {
            UserRepository repo = new UserRepository();
            return repo.GetUser(email, password);
        }

        public string LogInUser(LogInUserRequest modalRequest)
        {
            try
            {
                Dictionary<string, object> obj = new Dictionary<string, object>();

                UserRepository repo = new UserRepository();

                obj = repo.LogInUser(modalRequest);
                var result = new
                {
                    Users = obj["Users"]
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

        public string GetLogInCompanyInformation(Dictionary<string, object> param)
        {
            try
            {
                Dictionary<string, object> obj = new Dictionary<string, object>();
                UserRepository repo = new UserRepository();

                obj = repo.GetLogInCompanyInformation(param);

                var result = new
                {
                    Company = obj["CompanyInfo"],
                    Branch = obj["BranchInfo"],
                    Module = obj["ModuleInfo"],
                    menu = obj["menu"],
                    UserRoleRights = obj["UserRoleRights"],
                    UserMenuRoleRightWise = obj["UserMenuRoleRightWise"],
                    role = obj["role"],
                    actionType = obj["actionType"]
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

    }
}