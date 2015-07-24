using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWork1.Controllers
{
    public class VTController : Controller
    {
        // GET: VT
        public ActionResult Index()
        {
            ViewBag.IsShow = true;
            ViewBag.msg = "hello";

            ViewBag.num = new int[] { 1, 2, 3, 4, 5 };
            return PartialView();
        }
    }
}