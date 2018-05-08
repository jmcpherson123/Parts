using SampleWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleWeb.Controllers
{
    public class SortController : Controller
    {
        // GET: Sort
        public ActionResult Sort()
        {
            SortViewModel vm = new SortViewModel();
            vm.sortedString = "";
            vm.runTestString();
            return View(vm);
        }

        [HttpPost]
        public ActionResult SortString(SortViewModel vm)
        {
            vm.sortedString=vm.SortString(vm.getSentence);
            return View("Sort", vm);
        }

        public ActionResult SortInteger(SortViewModel vm)
        {
            vm.runTestInt();
            return View("Sort",vm);
        }
    }
}