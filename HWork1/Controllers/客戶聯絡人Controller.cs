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
    public class 客戶聯絡人Controller : BaseController
    {
        
        客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();
        客戶資料Repository repo_客 = RepositoryHelper.Get客戶資料Repository();

        // GET: 客戶聯絡人
        public ActionResult Index()
        {
            //var 客戶聯絡人 = db.客戶聯絡人.Include(客 => 客.客戶資料)
            //    .Where(客=>客.是否已刪除==false && 客.客戶資料.是否已刪除==false);
            var 客戶聯絡人 = repo.All().ToList();
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");             
            ViewBag.客戶Id = new SelectList(repo_客.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {

            var data = repo.Email重覆判斷(客戶聯絡人.Email, 客戶聯絡人.Id );
            //if (db.客戶聯絡人.Any(x=>x.Email == 客戶聯絡人.Email && x.Id != 客戶聯絡人.Id))
            if ( data.Any() )
            {
                ModelState.AddModelError("Email", "Email輸入不可重覆!!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //db.客戶聯絡人.Add(客戶聯絡人);
                    //db.SaveChanges();
                    repo.Add(客戶聯絡人);
                    repo.UnitOfWork.Commit();
                    return RedirectToAction("Index");
                }
            }            
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(repo_客.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(repo_客.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            var data = repo.Email重覆判斷(客戶聯絡人.Email, 客戶聯絡人.Id);
            //if (db.客戶聯絡人.Any(x=>x.Email == 客戶聯絡人.Email && x.客戶Id != 客戶聯絡人.Id))
            if( data.Any())
            {
                ModelState.AddModelError("Email", "Email不可重覆");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    //db.Entry(客戶聯絡人).State = EntityState.Modified;
                    //db.SaveChanges();
                    ((CusEntities)repo.UnitOfWork.Context).Entry(客戶聯絡人).State = EntityState.Modified;
                    repo.UnitOfWork.Commit();
                    return RedirectToAction("Index");
                }                                
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(repo_客.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            //db.客戶聯絡人.Remove(客戶聯絡人);
            客戶聯絡人 客戶聯絡人 = repo.Find(id);
            if (ModelState.IsValid)
            {
                //db.Entry(客戶聯絡人).State = EntityState.Modified;
                ((CusEntities)repo.UnitOfWork.Context).Entry(客戶聯絡人).State = EntityState.Modified;
                客戶聯絡人.是否已刪除 = true;
            }
            //db.SaveChanges();
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();               
                ((CusEntities)repo.UnitOfWork.Context).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
