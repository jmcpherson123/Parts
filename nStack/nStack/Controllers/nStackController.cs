using nStack.Helpers;
using nStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nStack.Controllers
{
    public class nStackController : Controller
    {
        // GET: nStack

        public ActionResult nStack()
        {
            //Read Data start here
            nStackViewModel vm = new nStackViewModel();
            vm = nStackHelper.setUpnStackWithoutSelection();
            return View(vm);
        }

        [HttpPost]
        public ActionResult nStack(nStackViewModel vm)
        {
            vm = nStackHelper.setUpnStackWithSelection(vm);
            return View(vm);
        }     
    }   
}