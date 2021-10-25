using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        //all items in Students page
        public ActionResult Students()
        {
            ViewBag.Title = "Students";
            ViewBag.Grades = "Students List";

            StudentsDBHandler studentsDBHandler = new StudentsDBHandler();
            ModelState.Clear();

            return View(studentsDBHandler.GetItemList());
        }

        // add new item 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentsModel iList)
        {
            // try
            //{
            if (ModelState.IsValid)
            {
                StudentsDBHandler ItemHandler = new StudentsDBHandler();
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
            StudentsDBHandler ItemHandler = new StudentsDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.StudentId == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, StudentsModel iList)
        {
            try
            {
                StudentsDBHandler ItemHandler = new StudentsDBHandler();
                ItemHandler.UpdateItem(iList);
                return RedirectToAction("Students");
            }
            catch { return View(); }
        }

        //delete item
        public ActionResult Delete(int id)
        {
            try
            {
                StudentsDBHandler ItemHandler = new StudentsDBHandler();
                if (ItemHandler.DeleteItem(id))
                {
                    ViewBag.AlertMsg = "Item Deleted Successfully";
                }
                return RedirectToAction("Students");
            }
            catch { return View(); }
        }

        public ActionResult Details(int id)
        {
            StudentsDBHandler ItemHandler = new StudentsDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.StudentId == id));
        }
    }
}