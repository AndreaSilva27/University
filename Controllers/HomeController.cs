using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Teachers()
        {
            ViewBag.Title = "Teachers";
            return View();
        }

        public ActionResult Students()
        {
            ViewBag.Title = "Students";
            return View();
        }
        public ActionResult Courses()
        {
            ViewBag.Title = "Courses";
            return View();

        }
        public ActionResult Subjects()
        {
            ViewBag.Title = "Subjects";
            return View();
        }
        public ActionResult Grades()
        {
            ViewBag.Title = "Grades";
            return View();
        }
        
        public ActionResult MyLayoutPage()
        {
            return View();
        }
    }
}