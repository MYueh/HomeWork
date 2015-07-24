using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace HWork1.ActionFilters
{
    public class MyFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            System.IO.File.AppendAllText(@"D:\MyFilter.log", "#1\n");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            System.IO.File.AppendAllText(@"D:\MyFilter.log", "#3\n");            
            base.OnActionExecuted(filterContext);
        }
    }
}