namespace Catalyst.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Catalyst.Core.Mvc;
    using Catalyst.Web.Models.Dashboard;

    /// <summary>
    /// A controller for rendering dashboard components.
    /// </summary>
    public class DashboardController : CatalystControllerBase
    {
        /// <summary>
        /// Returns the recently added box.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public ActionResult RecentlyAdded()
        {
            var model = new RecentlyAdded()
            {
                RecentlyUpdated = Services.Person.GetRecentlyUpdated(),
                TotalPeople = Services.Person.Count()
            };

            return PartialView(model);
        }

        /// <summary>
        /// Returns a placeholder for an asynchronous dashboard item.
        /// </summary>
        /// <param name="apiRouteId">
        /// The API route id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public ActionResult Placeholder(string apiRouteId)
        {
            var model = new AsyncPlaceholder { AjaxRouteAlias = apiRouteId };

            return PartialView(model);
        }

        /// <summary>
        /// Responsible for rendering the countries snap shot.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [CheckAjaxRequest]
        public ActionResult CountriesSnapshot()
        {
            var model = new CountriesSnapshot
                {
                    AjaxRouteAlias = Constants.AjaxRouteAliases.CompanySnapshot,
                    Metrics = Enumerable.Empty<CountryMetric>()
                };

            return PartialView(model);
        }
    }
}