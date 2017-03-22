namespace Catalyst.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}