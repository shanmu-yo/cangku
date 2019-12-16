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
    public class daohanglanguanliController : Controller
    {
        private kechenganpaiEntities db = new kechenganpaiEntities();

        // GET: daohanglanguanli
        public ActionResult Index()
        {
            return View(db.daohanglanguanli.ToList());
        }

        // GET: daohanglanguanli/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            daohanglanguanli daohanglanguanli = db.daohanglanguanli.Find(id);
            if (daohanglanguanli == null)
            {
                return HttpNotFound();
            }
            return View(daohanglanguanli);
        }

        // GET: daohanglanguanli/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: daohanglanguanli/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,controller,Action")] daohanglanguanli daohanglanguanli)
        {
            if (ModelState.IsValid)
            {
                db.daohanglanguanli.Add(daohanglanguanli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(daohanglanguanli);
        }

        // GET: daohanglanguanli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            daohanglanguanli daohanglanguanli = db.daohanglanguanli.Find(id);
            if (daohanglanguanli == null)
            {
                return HttpNotFound();
            }
            return View(daohanglanguanli);
        }

        // POST: daohanglanguanli/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,controller,Action")] daohanglanguanli daohanglanguanli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(daohanglanguanli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(daohanglanguanli);
        }

        // GET: daohanglanguanli/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            daohanglanguanli daohanglanguanli = db.daohanglanguanli.Find(id);
            if (daohanglanguanli == null)
            {
                return HttpNotFound();
            }
            return View(daohanglanguanli);
        }

        // POST: daohanglanguanli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            daohanglanguanli daohanglanguanli = db.daohanglanguanli.Find(id);
            db.daohanglanguanli.Remove(daohanglanguanli);
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
