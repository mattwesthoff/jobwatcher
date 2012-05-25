using System.Web.Mvc;
using AttributeRouting.Web.Mvc;

namespace jobwatcher.Controllers
{
    public class HomeController : Controller
    {
        [GET("/")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
