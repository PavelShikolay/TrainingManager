using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return Redirect("swagger/ui/index");
        }
    }
}
