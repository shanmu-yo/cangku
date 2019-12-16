using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace 课程安排.Models
{
    public class ActionLinkController : Controller
    {
        private kechenganpaiEntities db = new kechenganpaiEntities();

        // GET: ActionLink
        public ActionResult Index()
        {
            return View(db.ActionLink.ToList());
        }

        // GET: ActionLink/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionLink actionLink = db.ActionLink.Find(id);
            if (actionLink == null)
            {
                return HttpNotFound();
            }
            return View(actionLink);
        }

        // GET: ActionLink/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActionLink/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Controller,Action")] ActionLink actionLink)
        {
            if (ModelState.IsValid)
            {
                db.ActionLink.Add(actionLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actionLink);
        }

        // GET: ActionLink/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionLink actionLink = db.ActionLink.Find(id);
            if (actionLink == null)
            {
                return HttpNotFound();
            }
            return View(actionLink);
        }

        // POST: ActionLink/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Controller,Action")] ActionLink actionLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actionLink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actionLink);
        }

        // GET: ActionLink/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionLink actionLink = db.ActionLink.Find(id);
            if (actionLink == null)
            {
                return HttpNotFound();
            }
            return View(actionLink);
        }

        // POST: ActionLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionLink actionLink = db.ActionLink.Find(id);
            db.ActionLink.Remove(actionLink);
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
