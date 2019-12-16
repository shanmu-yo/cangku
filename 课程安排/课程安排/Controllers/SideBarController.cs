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
    public class SideBarController : Controller
    {
        private kechenganpaiEntities db = new kechenganpaiEntities();

        // GET: SideBar
        public ActionResult Index()
        {
            return View(db.SideBar.ToList());
        }

        // GET: SideBar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SideBar sideBar = db.SideBar.Find(id);
            if (sideBar == null)
            {
                return HttpNotFound();
            }
            return View(sideBar);
        }

        // GET: SideBar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SideBar/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Controller,Action")] SideBar sideBar)
        {
            if (ModelState.IsValid)
            {
                db.SideBar.Add(sideBar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sideBar);
        }

        // GET: SideBar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SideBar sideBar = db.SideBar.Find(id);
            if (sideBar == null)
            {
                return HttpNotFound();
            }
            return View(sideBar);
        }

        // POST: SideBar/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Controller,Action")] SideBar sideBar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sideBar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sideBar);
        }

        // GET: SideBar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SideBar sideBar = db.SideBar.Find(id);
            if (sideBar == null)
            {
                return HttpNotFound();
            }
            return View(sideBar);
        }

        // POST: SideBar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SideBar sideBar = db.SideBar.Find(id);
            db.SideBar.Remove(sideBar);
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
