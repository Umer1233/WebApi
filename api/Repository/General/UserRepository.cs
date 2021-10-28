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
    public class UserRepository
    {
        string constr = "";
        public UserRepository()
        {
            this.constr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        }


        public Dictionary<string, List<object>> GetUsersList(Dictionary<string, object> dic, out long totalNumber)
        {
            Dictionary<string, List<object>> dictionary = new Dictionary<string, List<object>>();
            totalNumber = 0;
            List<object> list = new List<object>();
            try
            {
                DataSet ds = new DataSet();
                ds = ClsGeneral.GetDataSet("sp_GetUsers", dic);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var result = new
                    {
                        User_id = Convert.ToInt32(row["user_id"]),
                        User_code = Convert.ToString(row["user_code"]),
                        User_name = Convert.ToString(row["user_name"]),
                        Email_address = Convert.ToString(row["email_address"]),
                        Password = Convert.ToString(row["password"]),
                        IsActive = Convert.ToBoolean(row["active"]),
                        Created_by = Convert.ToInt32(row["created_by"]),
                        Modify_by = Convert.ToInt32(row["modify_by"]),
                        Created_on = Convert.ToString(row["created_on"]),
                        Modify_on = Convert.ToString(row["modify_on"]),
                    };

                    list.Add(result);
                }

                dictionary.Add("Users", list);

                totalNumber = Convert.ToInt64(ds.Tables[0].Rows.Count.ToString());

                return dictionary;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Dictionary<string, object> Find_View_By_ID(int user_id)
        {
            Dictionary<string, object> SingleUser = new Dictionary<string, object>();

            List<object> list = new List<object>();
            try
            {
                DataTable dt = new DataTable();
                dt = ClsGeneral.GetDataTable("SELECT * FROM tblUser WHERE user_id=" + user_id);
                foreach (DataRow row in dt.Rows)
                {
                    var result = new
                    {
                        User_id = Convert.ToInt32(row["user_id"]),
                        User_code = Convert.ToString(row["user_code"]),
                        User_name = Convert.ToString(row["user_name"]),
                        Email_address = Convert.ToString(row["email_address"]),
                        Password = Convert.ToString(row["password"]),
                        IsActive = Convert.ToBoolean(row["active"]),
                        Created_by = Convert.ToInt32(row["created_by"]),
                        Modify_by = Convert.ToInt32(row["modify_by"]),
                        Created_on = Convert.ToString(row["created_on"]),
                        Modify_on = Convert.ToString(row["modify_on"]),
                    };

                    list.Add(result);
                }

                SingleUser.Add("Users", list);

                return SingleUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteUsers(int[] user_ids)
        {
            string SqlQuery = "";
            bool result = false;
            int EffectedRows = 0;
            try
            {
                SqlQuery = SqlQueryUserDelete(user_ids);
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

        public bool UpdateUser(UserRequest UserObject)
        {
            string SqlQuery = "";
            bool result = false;
            int EffectedRows = 0;
            try
            {
                SqlQuery = SqlQueryUpdateUser(UserObject);
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

        public bool SaveUsers(UserRequest UserObject)
        {
            string SqlQuery = "";
            bool result = false;
            int EffectedRows = 0;
            try
            {
                SqlQuery = SqlQueryInsertUser(UserObject);
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

        public bool GetUser(string email , string password)
        {
            DataTable dt = new DataTable();
            bool isExists = false;
            try
            {
                dt = ClsGeneral.GetDataTable("SELECT * FROM tblUser WHERE email_address='" + email + "' AND password='" + password + "'");
                if (dt.Rows.Count > 0) {
                    isExists = true;
                }
                else {
                    isExists = false ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isExists;
        }


        public Dictionary<string, object> LogInUser(LogInUserRequest obj)
        {
            DataTable dt = new DataTable();
            Dictionary<string, object> LogIn = new Dictionary<string, object>();
            List<object> list = new List<object>();
            try
            {

                dt = ClsGeneral.GetDataTable("SELECT * FROM tblUser WHERE email_address='" + obj.Email + "' AND password='" + obj.Password + "'");
                foreach (DataRow row in dt.Rows)
                {
                    var result = new
                    {
                        User_id = Convert.ToInt64(row["User_ID"]),
                        User_code = Convert.ToString(row["User_code"]),
                        User_name = Convert.ToString(row["User_name"]),
                        Email_address = Convert.ToString(row["Email_address"]),
                        Password = Convert.ToString(row["Password"]),
                        IsActive = Convert.ToBoolean(row["Active"]),
                        IsAdmin = Convert.ToBoolean(row["IsAdmin"]),
                        Role_ID = Convert.ToInt64(row["Role_ID"]),
                        Created_by = Convert.ToInt64(row["Created_by"]),
                        Modify_by = Convert.ToInt64(row["Modify_by"]),
                        Created_on = Convert.ToString(row["Created_on"]),
                        Modify_on = Convert.ToString(row["Modify_On"]),
                        Company_ID = Convert.ToInt64(row["Company_ID"]),
                        Branch_ID = Convert.ToInt64(row["Branch_ID"])
                    };

                    list.Add(result);
                }

                LogIn.Add("Users", list);

                return LogIn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Dictionary<string, object> GetLogInCompanyInformation(Dictionary<string, object> param)
        {
            DataSet ds = new DataSet();
            Dictionary<string, object> dic = new Dictionary<string, object>();

            List<object> list = new List<object>();
            try
            {
                ds = ClsGeneral.GetDataSet("sp_LogInWithCompanyInfomation", param);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    var result = new
                    {
                        Company_ID = Convert.ToInt64(row["Company_ID"]),
                        Company_code = Convert.ToString(row["Company_code"]),
                        Description = Convert.ToString(row["Description"]),
                        Address = Convert.ToString(row["Address"]),
                        City_ID = Convert.ToInt64(row["City_ID"]),
                        Phone = Convert.ToString(row["Phone"]),
                        Fax = Convert.ToString(row["Fax"]),
                        Email = Convert.ToString(row["Email"]),
                        Url = Convert.ToString(row["Url"]),
                        Ntnno = Convert.ToString(row["Ntnno"]),
                        Gstno = Convert.ToString(row["Gstno"]),
                        Active = Convert.ToBoolean(row["Active"]),
                        Created_on = Convert.ToString(row["Created_on"]),
                        Created_by = Convert.ToInt64(row["Created_by"]),
                        Modify_on = Convert.ToString(row["Modify_on"]),
                        Modify_by = Convert.ToInt64(row["Modify_by"])
                    };

                    list.Add(result);
                }

                dic.Add("CompanyInfo", list);


                list = new List<object>();
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var result = new
                    {
                        Branch_ID = Convert.ToInt64(row["Branch_ID"]),
                        Company_ID = Convert.ToInt64(row["Company_ID"]),
                        Branch_code = Convert.ToString(row["Branch_code"]),
                        Branch_name = Convert.ToString(row["Branch_name"]),
                        Address = Convert.ToString(row["Address"]),
                        City_ID = Convert.ToInt64(row["City_ID"]),
                        Phone = Convert.ToString(row["Phone"]),
                        Fax = Convert.ToString(row["Fax"]),
                        Email = Convert.ToString(row["Email"]),
                        Active = Convert.ToBoolean(row["Active"]),
                        Created_on = Convert.ToString(row["Created_on"]),
                        Created_by = Convert.ToInt64(row["Created_by"]),
                        Modify_on = Convert.ToString(row["Modify_on"]),
                        Modify_by = Convert.ToInt64(row["Modify_by"])
                    };

                    list.Add(result);
                }

                dic.Add("BranchInfo", list);

                list = new List<object>();
                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    var result = new
                    {
                        Module_id = Convert.ToInt64(row["Module_id"]),
                        Module_Type_ID = Convert.ToInt64(row["Module_Type_ID"]),
                        Module_Name = Convert.ToString(row["Module_Name"]),
                        Active = Convert.ToBoolean(row["Active"]),
                        Seq = Convert.ToInt64(row["Seq"])
                    };

                    list.Add(result);
                }

                dic.Add("ModuleInfo", list);

                list = new List<object>();
                foreach (DataRow row in ds.Tables[3].Rows)
                {
                    var result = new
                    {
                        Menu_ID = Convert.ToInt64(row["Menu_ID"]),
                        Menu_Name = Convert.ToString(row["Menu_Name"]),
                        path = Convert.ToString(row["path"]),
                        component = Convert.ToString(row["component"]),
                        redirectTo = Convert.ToString(row["redirectTo"]),
                        pathMatch = Convert.ToString(row["pathMatch"]),
                        module = Convert.ToString(row["module"]),
                        childRoute = Convert.ToString(row["childRoute"]),
                        MenuType = Convert.ToString(row["MenuType"]),
                        HaveSubMenu = Convert.ToBoolean(row["haveSubMenu"]),
                        IsSubMenu = Convert.ToBoolean(row["isSubMenu"]),
                        breadCrums = Convert.ToString(row["breadCrums"]),
                        Menu_Category_ID = Convert.ToInt64(row["Menu_Category_ID"]),
                        Module_ID = Convert.ToInt64(row["Module_ID"]),
                        Company_ID = Convert.ToInt64(row["Company_ID"]),
                        Branch_ID = Convert.ToInt64(row["Branch_ID"]),
                        Seq = Convert.ToInt64(row["Seq"]),
                        Active = Convert.ToBoolean(row["Active"]),
                        Created_on = Convert.ToString(row["Created_on"]),
                        Created_by = Convert.ToInt64(row["Created_by"]),
                        Modify_on = Convert.ToString(row["Modify_on"]),
                        Modify_by = Convert.ToInt64(row["Modify_by"])
                    };

                    list.Add(result);
                }

                dic.Add("menu", list);

                list = new List<object>();
                foreach (DataRow row in ds.Tables[4].Rows)
                {
                    var result = new
                    {
                        User_Role_Rights_ID = Convert.ToInt64(row["User_Role_Rights_ID"]),
                        User_ID = Convert.ToInt64(row["User_ID"]),
                        Menu_ID = Convert.ToInt64(row["Menu_ID"]),
                        Action_Type_ID = Convert.ToInt64(row["Action_Type_ID"]),
                    };

                    list.Add(result);
                }

                dic.Add("UserRoleRights", list);

                //Menu For User
                list = new List<object>();
                foreach (DataRow row in ds.Tables[5].Rows)
                {
                    var result = new
                    {
                        Menu_ID = Convert.ToInt64(row["Menu_ID"]),
                        Menu_Name = Convert.ToString(row["Menu_Name"]),
                        path = Convert.ToString(row["path"]),
                        component = Convert.ToString(row["component"]),
                        redirectTo = Convert.ToString(row["redirectTo"]),
                        pathMatch = Convert.ToString(row["pathMatch"]),
                        module = Convert.ToString(row["module"]),
                        childRoute = Convert.ToString(row["childRoute"]),
                        MenuType = Convert.ToString(row["MenuType"]),
                        HaveSubMenu = Convert.ToBoolean(row["haveSubMenu"]),
                        IsSubMenu = Convert.ToBoolean(row["isSubMenu"]),
                        breadCrums = Convert.ToString(row["breadCrums"]),
                        Menu_Category_ID = Convert.ToInt64(row["Menu_Category_ID"]),
                        Module_ID = Convert.ToInt64(row["Module_ID"]),
                        Company_ID = Convert.ToInt64(row["Company_ID"]),
                        Branch_ID = Convert.ToInt64(row["Branch_ID"]),
                        Seq = Convert.ToInt64(row["Seq"]),
                        Active = Convert.ToBoolean(row["Active"]),
                        Created_on = Convert.ToString(row["Created_on"]),
                        Created_by = Convert.ToInt64(row["Created_by"]),
                        Modify_on = Convert.ToString(row["Modify_on"]),
                        Modify_by = Convert.ToInt64(row["Modify_by"])
                    };

                    list.Add(result);
                }
                dic.Add("UserMenuRoleRightWise", list);

                list = new List<object>();
                foreach (DataRow row in ds.Tables[6].Rows)
                {
                    var result = new
                    {
                        Role_ID = Convert.ToInt64(row["Role_ID"]),
                        Role_Name = Convert.ToString(row["Role_Name"])
                    };

                    list.Add(result);
                }

                dic.Add("role", list);

                list = new List<object>();
                foreach (DataRow row in ds.Tables[7].Rows)
                {
                    var result = new
                    {
                        Action_Type_ID = Convert.ToInt64(row["Action_Type_ID"]),
                        Action_Name = Convert.ToString(row["Action_Name"])
                    };

                    list.Add(result);
                }

                dic.Add("actionType", list);



                return dic;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private string SqlQueryUpdateUser(UserRequest obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("UPDATE [tblUser] SET [user_code] = '{0}',[user_name] = '{1}',[email_address] ='{2}' ", obj.User_code, obj.User_name, obj.Email_address);
            sb.AppendFormat(",[password]='{0}',[active]={1},[created_on]='{2}',[created_by]={3},[modify_on]='{4}',[modify_by]={5}", obj.Password, obj.IsActive, obj.Created_on, obj.Created_by, obj.Modify_on, obj.Modify_by);
            sb.AppendFormat("  WHERE user_id ={0}", obj.User_id);
            return sb.ToString();
        }

        private string SqlQueryInsertUser(UserRequest obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO tblUser ([user_code],[user_name],[email_address],[password],[active],[created_on],[created_by],[modify_on],[modify_by])");
            sb.AppendFormat(" VALUES ");
            sb.AppendFormat(" ('{0}','{1}','{2}','{3}',{4} ", obj.User_code, obj.User_name, obj.Email_address, obj.Password, obj.IsActive);
            sb.AppendFormat(" ,'{0}',{1},'{2}',{3} )", obj.Created_on, obj.Created_by, obj.Modify_on, obj.Modify_by);
            return sb.ToString();
        }

        private string SqlQueryUserDelete(int[] userIDs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int item in userIDs)
            {
                sb.AppendFormat("DELETE FROM tblUser WHERE UserID={0}", item);
            }
            return sb.ToString();
        }

    }
}