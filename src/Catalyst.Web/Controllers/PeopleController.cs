namespace Catalyst.Web.Controllers
{
    using Catalyst.Core;
    using System.Web.Mvc;

    /// <summary>
    /// The people controller.
    /// </summary>
    public class PeopleController : CatalystControllerBase
    {
        /// <inheritdoc />
        public override ActionResult Index()
        {
            return List();
        }

        /// <summary>
        /// Renders the peoples "List" view.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult List()
        {
            return View("List");
        }

        /// <summary>
        /// Renders a view with a "Person" details.
        /// </summary>
        /// <param name="slug">
        /// The slug.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult PersonDetails(string slug)
        {
            if (slug.IsNullOrWhiteSpace()) return RedirectToAction("List");

            return View("PersonDetails", (object)slug);
        }
    }
}