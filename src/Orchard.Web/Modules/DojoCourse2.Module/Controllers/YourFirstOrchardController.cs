using Orchard.Themes;
using System.Web.Mvc;

namespace DojoCourse2.Module.Controllers
{
    public class YourFirstOrchardController : Controller
    {
        [Themed]
        public ActionResult Index()
        {
            return View();
        }
    }
}