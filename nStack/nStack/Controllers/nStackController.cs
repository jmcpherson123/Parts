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
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase[] file, UploadViewModel vm)
        {
            FileReader fileReader = new FileReader();
            if (file.Count() > 1)
            {
                var compName = vm.CompanyName.Split(',').ToList();
                int i = 0;
                foreach (var fileUploaded in file)
                {
                    vm.ReadData = fileReader.getBinFileObject(fileUploaded, compName.ElementAt(i));
                    SaveData saveObject = new SaveData(vm.ReadData);
                    i++;
                }
            }
            else
            {
                vm.ReadData = fileReader.getBinFileObject(file[0], vm.CompanyName);
                SaveData saveObject = new SaveData(vm.ReadData);
            }
            return View(vm);
        }
    }
}