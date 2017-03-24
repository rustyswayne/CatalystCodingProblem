namespace Catalyst.Web.Controllers
{
    using System.Web.Mvc;

    using Catalyst.Web.Models;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : CatalystControllerBase
    {
        /// <summary>
        /// The default action.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public override ActionResult Index()
        {
            var model = new Home
            {
                Meta =
                    {
                        PageTitle = "Home - People Problem",
                        Description = "Reads contents of Readme.md file and displays as content"
                    }
            };

            return View(model);
        }
    }
}