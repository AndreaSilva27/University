using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }

        //all items in Courses page
        public ActionResult Courses()
        {
            ViewBag.Title = "Courses";
            ViewBag.Grades = "Courses List";

            CoursesDBHandler coursesDBHandler = new CoursesDBHandler();
            ModelState.Clear();

            return View(coursesDBHandler.GetItemList());
        }

        // add new item 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CoursesModel iList)
        {
            // try
            //{
            if (ModelState.IsValid)
            {
                CoursesDBHandler ItemHandler = new CoursesDBHandler();
                if (ItemHandler.InsertItem(iList))
                {
                    ViewBag.Message = "Item Added Successfully";
                    ModelState.Clear();
                }
            }
            return View();
            /* }
             catch { return View();  }*/
        }

        //update item
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CoursesDBHandler ItemHandler = new CoursesDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.CourseId == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, CoursesModel iList)
        {
            try
            {
                CoursesDBHandler ItemHandler = new CoursesDBHandler();
                ItemHandler.UpdateItem(iList);
                return RedirectToAction("Courses");
            }
            catch { return View(); }
        }

        //delete item
        public ActionResult Delete(int id)
        {
            try
            {
                CoursesDBHandler ItemHandler = new CoursesDBHandler();
                if (ItemHandler.DeleteItem(id))
                {
                    ViewBag.AlertMsg = "Item Deleted Successfully";
                }
                return RedirectToAction("Courses");
            }
            catch { return View(); }
        }

        public ActionResult Details(int id)
        {
            CoursesDBHandler ItemHandler = new CoursesDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.CourseId == id));
        }
    }
}