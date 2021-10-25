using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace University.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index1()
        {
            ViewBag.ItemList = "UCL Management List Page";
            return View();
        }

        
    }
}