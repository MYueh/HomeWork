using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HWork1.Models;

namespace HWork1.Controllers
{
    public class 客戶資料Controller : Controller
    {
        private CusEntities db = new CusEntities();
       
        // GET: 客戶資料
        public ActionResult Index()
        {   
            var query = db.客戶資料.Where(x=>x.是否已刪除 == false).ToList();
            return View(query);                
        }

        // 報表List
        public ActionResult CustomerList()
        {
            var query = db.V_CUSLIST.OrderBy(x => x.CID).AsQueryable();
            return View(query);
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (db.客戶資料.Any(x=>x.Email == 客戶資料.Email))
            {
                ModelState.AddModelError("Email", "Email輸入不可重覆");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.客戶資料.Add(客戶資料);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }            
            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (db.客戶資料.Any(x => x.Email == 客戶資料.Email))
            {
                ModelState.AddModelError("Email", "Email輸入不可重覆");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(客戶資料).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料);
            if (ModelState.IsValid)
            {
                db.Entry(客戶資料).State = EntityState.Modified; 
                客戶資料.是否已刪除 = true;                
            } 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
