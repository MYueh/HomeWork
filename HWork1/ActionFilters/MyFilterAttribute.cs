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
            System.IO.File.AppendAllText(@"D:\MyFilter.log", "#1 OnActionExcuting \n");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            System.IO.File.AppendAllText(@"D:\MyFilter.log", "#3 OnActionExcuted \n");
            base.OnActionExecuted(filterContext);
        }


        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            System.IO.File.AppendAllText(@"D:\MyFilter.log", "#4 OnResultExcuting \n");
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            System.IO.File.AppendAllText(@"D:\MyFilter.log", "#6 OnResultExcuted \n");
            base.OnResultExecuted(filterContext);
        }
    }
}