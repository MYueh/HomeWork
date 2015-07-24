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
        [取得共用的ViewBag資料]
        public ActionResult Index()
        {
            //System.IO.File.AppendAllText(@"D:\MyFilter.log", "#2\n");
            //return Content("Done");

            System.IO.File.AppendAllText(@"D:\MyFilter.log", "#2 AFController.Index()\n");
            //throw new Exception("Index failed");
            return View();
        }

        [取得共用的ViewBag資料]
        public ActionResult Page1() 
        {
            return View();
        }
    }
}