using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Models;

namespace University.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Teachers
        public ActionResult Index()
        {
            return View();
        }

        //all items in Teachers page
        public ActionResult Teachers()
        {
            ViewBag.Title = "Teachers";
            ViewBag.Teachers = "Teachers List";

            TeachersDBHandler teachersDBHandler = new TeachersDBHandler();
            ModelState.Clear();

            return View(teachersDBHandler.GetItemList());
        }

        // add new item 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TeachersModel iList)
        {
            // try
            //{
            if (ModelState.IsValid)
            {
                TeachersDBHandler ItemHandler = new TeachersDBHandler();
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
            TeachersDBHandler ItemHandler = new TeachersDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.TeacherId == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, TeachersModel iList)
        {
            try
            {
                TeachersDBHandler ItemHandler = new TeachersDBHandler();
                ItemHandler.UpdateItem(iList);
                return RedirectToAction("Teachers");
            }
            catch { return View(); }
        }

        //delete item
        public ActionResult Delete(int id)
        {
            try
            {
                TeachersDBHandler ItemHandler = new TeachersDBHandler();
                if (ItemHandler.DeleteItem(id))
                {
                    ViewBag.AlertMsg = "Item Deleted Successfully";
                }
                return RedirectToAction("Teachers");
            }
            catch { return View(); }
        }

        public ActionResult Details(int id)
        {
            TeachersDBHandler ItemHandler = new TeachersDBHandler();
            return View(ItemHandler.GetItemList().Find(itemmodel => itemmodel.TeacherId == id));
        }
    }
}