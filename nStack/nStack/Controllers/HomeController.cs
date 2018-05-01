using nStack.Helpers;

using nStack.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nStack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult nGauge()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase[] file, UploadViewModel vm)
        {
            FileReader fileReader = new FileReader();
            vm = fileReader.getBinFileObject(file, vm);
            return View(vm);
        }
    }
}