using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProTrukWeb.CustomFilters
{
    public class UserAuthenticationFilter : System.Web.Mvc.ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userID =(string) filterContext.HttpContext.Session["UserID"];

            if (userID== null || userID =="" )
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{{ "controller", "Account" },
                                          { "action", "Login" }

                                         });

            }

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}