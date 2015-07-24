using HWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWork1.Controllers
{
    //[MyFilter]
#if !DEBUG
    [Authorize]
#endif

    public class BaseController : Controller
    {
        // GET: Base
        //把 dbContext 搬到 BaseController 讓其它Controller繼承BaseController
        protected CusEntities db = new CusEntities();

        public string MyMethod()
        {
            return "";
        }
        protected override void HandleUnknownAction(string actionName)
        {
            if (this.ControllerContext.HttpContext.Request.HttpMethod.ToUpper() == "GET")            
            {
                this.Redirect("/").ExecuteResult(this.ControllerContext);
            }
            else
            {
                base.HandleUnknownAction(actionName);
            }            
        }
    }
}