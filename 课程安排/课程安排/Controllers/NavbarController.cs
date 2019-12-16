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
    public class NavbarController : Controller
    {
        private kechenganpaiEntities db = new kechenganpaiEntities();

        // GET: Navbar
        public ActionResult Index()
        {
            return View(db.Navbar.ToList());
        }

        // GET: Navbar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navbar navbar = db.Navbar.Find(id);
            if (navbar == null)
            {
                return HttpNotFound();
            }
            return View(navbar);
        }

        // GET: Navbar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Navbar/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,controller,action")] Navbar navbar)
        {
            if (ModelState.IsValid)
            {
                db.Navbar.Add(navbar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(navbar);
        }

        // GET: Navbar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navbar navbar = db.Navbar.Find(id);
            if (navbar == null)
            {
                return HttpNotFound();
            }
            return View(navbar);
        }

        // POST: Navbar/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,controller,action")] Navbar navbar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(navbar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(navbar);
        }

        // GET: Navbar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Navbar navbar = db.Navbar.Find(id);
            if (navbar == null)
            {
                return HttpNotFound();
            }
            return View(navbar);
        }

        // POST: Navbar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Navbar navbar = db.Navbar.Find(id);
            db.Navbar.Remove(navbar);
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
