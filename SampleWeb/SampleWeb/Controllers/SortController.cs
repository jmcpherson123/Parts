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
            vm.runTestString();
            return View(vm);
        }
    }
}