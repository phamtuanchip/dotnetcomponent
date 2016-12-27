using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace MVC03.Filter
{
    public sealed class AllowJsonGetAttribute : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
        void System.Web.Mvc.IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            var jsonResult = context.Result as JsonResult;
            if (jsonResult == null) return;

            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var jsonResult = filterContext.Result as JsonResult;
            if (jsonResult == null) return;

            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            base.OnResultExecuting(filterContext);
        }
    }
}