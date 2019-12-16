using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 课程安排.Models;

namespace 课程安排.Controllers
{
    public class HomeController : Controller
    {
        private kechenganpaiEntities db = new kechenganpaiEntities();
        public ActionResult Index()
        {
           
            return View();
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public ActionResult SideBar()
        {
            var sidebars = db.SideBar.ToList();
            ViewBag.sidebar = sidebars;
            return PartialView("~/Views/Shared/SideBar.cshtml");
        }
        [ChildActionOnly]
        public ActionResult Navbar()
        {
            var site = new WebsiteInfo();
            ViewBag.Site = site;
            site.ActionLinks = db.ActionLink.ToList();
            return PartialView("~/Views/Shared/Navbar.cshtml");
        }
    }
}