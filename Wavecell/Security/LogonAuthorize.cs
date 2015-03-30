using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Wavecell.Security
{
    public sealed class LogonAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                                     ||
                                     filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                                         typeof(AllowAnonymousAttribute), true);
            if (!skipAuthorization)
            {
                base.OnAuthorization(filterContext);
                OnAuthorizationHelp(filterContext);
            }
        }

        internal void OnAuthorizationHelp(AuthorizationContext filterContext)
        {

            if (filterContext.Result is HttpUnauthorizedResult)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;

                    //filterContext.Result = new JsonResult()
                    //{
                    //    Data = new { Errors = "Unauthorize user. Please log in." }
                    //};

                    filterContext.HttpContext.Response.End();
                }
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class AllowAnonymousAttribute : Attribute
    {
    }
}
