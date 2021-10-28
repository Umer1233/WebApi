using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Controllers.Response
{
    public class LogInCompanyInfo
    {
        List<UserResponse> lstUser;
        List<CompanyResponse> lstCompany;
        List<ModuleResponse> lstModule;
        List<UserMenuResponse> lstMenu;
        List<BranchResponse> lstBranch;
        List<CompanyFlagResponse> lstCompanyFlag;
        List<UserRoleRightsResponse> lstUserMenuRights;
        List<UserMenuResponse> lstUserMenuRoleRightsWise;
        List<RoleResponse> lstRole;
        List<ActionTypeResponse> lstActionType;


        [JsonProperty(PropertyName = "actionType")]
        public List<ActionTypeResponse> actionTypeList
        {
            get
            {
                if (lstActionType == null) lstActionType = new List<ActionTypeResponse>();
                return lstActionType;
            }
        }

        [JsonProperty(PropertyName = "roles")]
        public List<RoleResponse> roleList
        {
            get
            {
                if (lstRole == null) lstRole = new List<RoleResponse>();
                return lstRole;
            }
        }

        [JsonProperty(PropertyName = "UserRoleRights")]
        public List<UserRoleRightsResponse> UserRoleRightsList
        {
            get
            {
                if (lstUserMenuRights == null) lstUserMenuRights = new List<UserRoleRightsResponse>();
                return lstUserMenuRights;
            }
        }

        [JsonProperty(PropertyName = "UserMenuRoleRightsWise")]
        public List<UserMenuResponse> UserMenuRoleRightsList
        {
            get
            {
                if (lstUserMenuRoleRightsWise == null) lstUserMenuRoleRightsWise = new List<UserMenuResponse>();
                return lstUserMenuRoleRightsWise;
            }
        }


        [JsonProperty(PropertyName = "LogCompanyFlag")]
        public List<CompanyFlagResponse> CompanyFlagList
        {
            get
            {
                if (lstCompanyFlag == null) lstCompanyFlag = new List<CompanyFlagResponse>();
                return lstCompanyFlag;
            }
        }

        [JsonProperty(PropertyName = "LogInUser")]
        public List<UserResponse> UserList
        {
            get
            {
                if (lstUser == null) lstUser = new List<UserResponse>();
                return lstUser;
            }
        }

        [JsonProperty(PropertyName = "LogInCompany")]
        public List<CompanyResponse> CompanyList
        {
            get
            {
                if (lstCompany == null) lstCompany = new List<CompanyResponse>();
                return lstCompany;
            }
        }

        [JsonProperty(PropertyName = "LogInBranch")]
        public List<BranchResponse> BranchList
        {
            get
            {
                if (lstBranch == null) lstBranch = new List<BranchResponse>();
                return lstBranch;
            }
        }

        [JsonProperty(PropertyName = "LogInModule")]
        public List<ModuleResponse> ModuleList
        {
            get
            {
                if (lstModule == null) lstModule = new List<ModuleResponse>();
                return lstModule;
            }
        }

        [JsonProperty(PropertyName = "LogInMenu")]
        public List<UserMenuResponse> MenuList
        {
            get
            {
                if (lstMenu == null) lstMenu = new List<UserMenuResponse>();
                return lstMenu;
            }
        }

        public LogInCompanyInfo()   { }
    }
}