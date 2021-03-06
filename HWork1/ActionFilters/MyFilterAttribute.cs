﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace HWork1.ActionFilters
{
    public class 取得共用的ViewBag資料Attribute : ActionFilterAttribute, IExceptionFilter    //IExceptionFilter定義例外狀況篩選條件
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            File.AppendAllText(@"D:\MyFilter.log", "#1 OnActionExcuting-" +filterContext.RouteData.Values["controller"]+"."+filterContext.RouteData.Values["action"]+"()\n");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            File.AppendAllText(@"D:\MyFilter.log", "#3 OnActionExcuted-" + filterContext.RouteData.Values["controller"] + "." + filterContext.RouteData.Values["action"] + "()\n");
            base.OnActionExecuted(filterContext);
        }


        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            File.AppendAllText(@"D:\MyFilter.log", "#4 OnResultExcuting-" + filterContext.RouteData.Values["controller"] + "." + filterContext.RouteData.Values["action"] + "()\n");
            base.OnResultExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            File.AppendAllText(@"D:\MyFilter.log", "#6 OnResultExcuted-" + filterContext.RouteData.Values["controller"] + "." + filterContext.RouteData.Values["action"] + "()\n");
            base.OnResultExecuted(filterContext);
        }

        public void OnException(ExceptionContext filterContext)    //IExceptionFilter定義例外狀況篩選條件
        {
            File.AppendAllText(@"D:\MyFilter.log", "#7 OnException-" + filterContext.RouteData.Values["controller"] + "." + filterContext.RouteData.Values["action"] + "()\n");
        }
    }
}