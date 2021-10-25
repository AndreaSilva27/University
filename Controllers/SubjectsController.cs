using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class SubjectsController : Controller
    {
        // GET: Subjects
        public ActionResult Index()
        {
            return View();
        }

        //all items in Subjects page
        public ActionResult Subjects()
        {
            ViewBag.Title = "Subjects";
            ViewBag.Teachers = "Subjects List";

            SubjectsDBHandler subjectsDBHandler = new SubjectsDBHandler();
            ModelState.Clear();

            return View(subjectsDBHandler.GetItemList());
        }

        // add new item 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SubjectsModel iList)
        {
            // try
            //{
            if (ModelState.IsValid)
            {
                SubjectsDBHandler ItemHandler = new SubjectsDBHandler();
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
            SubjectsDBHandler ItemHandler = new SubjectsDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.SubjectId == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, SubjectsModel iList)
        {
            try
            {
                SubjectsDBHandler ItemHandler = new SubjectsDBHandler();
                ItemHandler.UpdateItem(iList);
                return RedirectToAction("Subjects");
            }
            catch { return View(); }
        }

        //delete item
        public ActionResult Delete(int id)
        {
            try
            {
                SubjectsDBHandler ItemHandler = new SubjectsDBHandler();
                if (ItemHandler.DeleteItem(id))
                {
                    ViewBag.AlertMsg = "Item Deleted Successfully";
                }
                return RedirectToAction("Subjects");
            }
            catch { return View(); }
        }

        public ActionResult Details(int id)
        {
            SubjectsDBHandler ItemHandler = new SubjectsDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.SubjectId == id));
        }
    }
}