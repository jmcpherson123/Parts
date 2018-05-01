using nStack.Helpers;
using nStack.ModelObjects;
using nStack.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace nStack.Controllers
{
    public class nTouchController : Controller
    {
        // GET: nTouch
        public ActionResult nTouch()
        {
            nTouchViewModel vm = new nTouchViewModel();
            vm.ListOfRequestItems = new List<ServiceCatalog>();
            vm.RequestVariable = new CatalogTaskVariable();
            vm.RequestVariable.Variables = new Dictionary<string, string>();
            return View(vm);
        }

        [HttpPost]
        public ActionResult nTouch(nTouchViewModel vm)
        {
            var ttttt = vm.ListOfRequestItems;

            vm.ListOfRequestItems = new List<ServiceCatalog>();
            List<string> har = new List<string>();
            ServiceNowScriptHelper scriptHelper = new ServiceNowScriptHelper();
            
            if (vm.sc_req_item != null)
            {
                har = scriptHelper.get_sc_req_items(vm.sc_req_item);
            }
            if (vm.sc_task != null)
            {
                vm.ListOfRequestItems = scriptHelper.clean_sc_task(vm.sc_task, har);
            }
            if (vm.sc_item_option_otom != null)
            {
                vm = scriptHelper.clean_sc_item_option_otom(vm.sc_item_option_otom, vm);
            }
            if (vm.request_variable != null)
            {
            }
            vm.RequestVariable = new CatalogTaskVariable();
            vm.RequestVariable.Variables = new Dictionary<string, string>();
            return View(vm);
        }
    }
}
   