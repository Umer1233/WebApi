using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace api.Security
{
    public class AuthFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else 
            {
                //https://www.youtube.com/watch?v=BZnmhyZzKgs&list=PL6n9fhu94yhW7yoUOGNOfHurUE6bpOO2b&index=18
                string token = actionContext.Request.Headers.Authorization.Parameter;
            }
        }
    }
}