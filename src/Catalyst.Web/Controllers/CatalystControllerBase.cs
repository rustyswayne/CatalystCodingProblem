namespace Catalyst.Web.Controllers
{
    using System.Web.Mvc;

    public abstract class CatalystControllerBase : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}