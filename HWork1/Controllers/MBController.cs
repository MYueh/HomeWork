using HWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWork1.Controllers
{
    public class MBController : BaseController    //ModelBinding Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SampleVM data)
        {
            if(ModelState.IsValid)
            {
                TempData["IndexSaveMsg"] = "新增" + data.Name + "成功";
                return RedirectToAction("IndexResult");
            }
            return View(data);
        }

        public ActionResult IndexResult()
        {
            return View();
        }
    }
}


//24 練習建立 ViewModel、套用模型繫結、表單驗證、使用 TempData 傳資料
//* 建立 MBController (空白控制器)
//* 建立 SampleVM 並套用 [Required] 屬性
//* 建立 /Views/MB/Index.cshtml ( 使用 Create 範本 )
//* 建立 [HttpPost] Index(SampleVM data) 動作方法，驗證 ModelState.IsValid 檢查驗證結果是否正確，若驗證正確請寫訊息到 TempData 裡面，並回傳 RedirectToActionResult 到 IndexResult 頁面
//* 建立 IndexResult 動作方法，並建立 /Views/MB/IndexResult.cshtml 頁面