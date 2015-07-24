using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWork1.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR -- ActionResult 動作結果
        public ActionResult Index()    //ViewResult用法
        {
            string str = "Hello word!!";    
            return View((object)str);       //string物件透過 @Model顯示
        }
        public ActionResult PartialViewTest()  //PartialViewResutl 
        {
            return PartialView("MyPartial");
        }

        //==ContentResult===
        public ActionResult ContentTest()     //Conttent回傳text
        {
            return Content("<h2>Content Text</h2>", "text/plain");
        }
        public ActionResult ContentTest2()   //Content回傳script導至根目錄
        {
            return Content("<script>alert('新增成功'); location.href='/';</script>");
        }
        public ActionResult ContentTest3()   //View 回傳script並帶入ViewBag.msg
        {
            ViewBag.msg = "新增成功";
            return View("AlertRedirect");
        }
        //==========

        public ActionResult FileTest()    //FileResult--顯示圖片&直接下載
        {
            return File(Server.MapPath("~/Content/coder-630x276.jpg"), "image/png", "圖片下載.jpg"); 
        }
        public ActionResult JsonTest()    //JsonResult--載入Json資料
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.客戶資料.Take(5);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}