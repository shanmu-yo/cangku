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
    public class coursemenagementController : Controller
    {
        private kechenganpaiEntities db = new kechenganpaiEntities();

        // GET: coursemenagement
        public ActionResult Index()
        {

            return View(db.coursemenagements.ToList());
        }

        // GET: coursemenagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coursemenagements coursemenagements = db.coursemenagements.Find(id);
            if (coursemenagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemenagements);
        }

        // GET: coursemenagement/Create
        public ActionResult Create()
        {

            var teachers = db.teacher.ToList();
            ViewBag.teacher = teachers;
            var classs= db.classes.ToList();
            ViewBag.classes = classs;
            var kebiaos = db.kebiao.ToList();
            ViewBag.kebiao = kebiaos;
            return View();
        }

        // POST: coursemenagement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,classid,courseid,teacherid")] coursemenagements coursemenagements)
        {
            if (ModelState.IsValid)
            {
                db.coursemenagements.Add(coursemenagements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursemenagements);
        }

        // GET: coursemenagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coursemenagements coursemenagements = db.coursemenagements.Find(id);
            if (coursemenagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemenagements);
        }

        // POST: coursemenagement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,classid,courseid,teacherid")] coursemenagements coursemenagements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursemenagements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursemenagements);
        }

        // GET: coursemenagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coursemenagements coursemenagements = db.coursemenagements.Find(id);
            if (coursemenagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemenagements);
        }

        // POST: coursemenagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            coursemenagements coursemenagements = db.coursemenagements.Find(id);
            db.coursemenagements.Remove(coursemenagements);
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
