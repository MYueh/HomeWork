using HWork1.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWork1.Controllers
{
    public class AFController : BaseController   //Action Filter
    {
        // GET: AF
        [MyFilter]
        public ActionResult Index()
        {
            System.IO.File.AppendAllText(@"D:\MyFilter.log", "#2\n");
            return Content("Done");
        }
    }
}