using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class GradesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
            // GET: Grades
            public ActionResult Grades()
        {
            ViewBag.Title = "Grades";
            ViewBag.Grades = "Grades List";

            GradesDBHandler gradesDBHandler = new GradesDBHandler();
            ModelState.Clear();

            return View(gradesDBHandler.GetItemList());
        }

        //all items in Grades page
       

        // add new item 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GradesModel iList)
        {
            // try
            //{
            if (ModelState.IsValid)
            {
                GradesDBHandler ItemHandler = new GradesDBHandler();
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
            GradesDBHandler ItemHandler = new GradesDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.Id == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, GradesModel iList)
        {
            try
            {
                GradesDBHandler ItemHandler = new GradesDBHandler();
                ItemHandler.UpdateItem(iList);
                return RedirectToAction("Grades");
            }
            catch { return View(); }
        }

        //delete item
        public ActionResult Delete(int id)
        {
            try
            {
                GradesDBHandler ItemHandler = new GradesDBHandler();
                if (ItemHandler.DeleteItem(id))
                {
                    ViewBag.AlertMsg = "Item Deleted Successfully";
                }
                return RedirectToAction("Grades");
            }
            catch { return View(); }
        }

        public ActionResult Details(int id)
        {
            GradesDBHandler ItemHandler = new GradesDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.Id == id));
        }
    }
}