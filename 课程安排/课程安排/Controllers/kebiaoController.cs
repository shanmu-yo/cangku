using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 课程安排.Models;

namespace 课程安排.Controllers
{
    public class kebiaoController : Controller
    {
        private kechenganpaiEntities db = new kechenganpaiEntities();

        // GET: kebiao
        public ActionResult Index()
        {
            return View(db.kebiao.ToList());
        }

        // GET: kebiao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kebiao kebiao = db.kebiao.Find(id);
            if (kebiao == null)
            {
                return HttpNotFound();
            }
            return View(kebiao);
        }

        // GET: kebiao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kebiao/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name")] kebiao kebiao)
        {
            if (ModelState.IsValid)
            {
                db.kebiao.Add(kebiao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kebiao);
        }

        // GET: kebiao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kebiao kebiao = db.kebiao.Find(id);
            if (kebiao == null)
            {
                return HttpNotFound();
            }
            return View(kebiao);
        }

        // POST: kebiao/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name")] kebiao kebiao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kebiao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kebiao);
        }

        // GET: kebiao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kebiao kebiao = db.kebiao.Find(id);
            if (kebiao == null)
            {
                return HttpNotFound();
            }
            return View(kebiao);
        }

        // POST: kebiao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kebiao kebiao = db.kebiao.Find(id);
            db.kebiao.Remove(kebiao);
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
