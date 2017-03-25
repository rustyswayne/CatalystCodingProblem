namespace Catalyst.Web.Controllers
{
    using System.Collections.Generic;
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
        /// Renders a placeholder for an asynchronous dashboard item.
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
        /// Renders the recently updated people.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public ActionResult RecentlyAdded()
        {
            var model = new PeopleListing("Recent Updates")
            {
                People = Services.Person.GetRecentlyUpdated(),
                ShowManage = true,
                TotalPeople = Services.Person.Count()
            };

            return PartialView("PeopleList", model);
        }

        /// <summary>
        /// Renders the people list.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public ActionResult PeopleList()
        {
            var people = Services.Person.GetAll().OrderBy(x => x.FirstName).ToArray();

            var model = new PeopleListing("All People")
            {
                People = people,
                ShowDelete = true,
                TotalPeople = people.Count()
            };

            return PartialView(model);
        }

        // - ASYNCHRONOUS ----------------

        /// <summary>
        /// Responsible for rendering "Country Snap Shot" dashboard item.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [CheckAjaxRequest]
        public ActionResult CountriesSnapshot()
        {

            var countries = Services.AddressService.GetAssociatedCountries();

            var metrics = new List<CountryMetric>();
            foreach (var c in countries)
            {
                metrics.Add(
                    new CountryMetric
                        {
                            CountryCode = c.Code,
                            EnglishCountryName = c.Name,
                            PeopleCount = Services.AddressService.GetPeopleCountryCount(c.Code)
                        });
            }

            var model = new CountriesSnapshot
                {
                    AjaxRouteAlias = Constants.AjaxRouteAliases.CompanySnapshot,
                    Metrics = metrics.OrderByDescending(x => x.PeopleCount).Take(5)
                };

            return PartialView(model);
        }

        /// <summary>
        /// Responsible for rendering the "People Property Stats" dashboard item.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [CheckAjaxRequest]
        public ActionResult PeoplePropertyStats()
        {
            var model = new PeoplePropertyStats
                {
                    AjaxRouteAlias = Constants.AjaxRouteAliases.PeoplePropertyStats
                };

            return PartialView(model);
        }

        /// <summary>
        /// Responsible for rendering the "Random Last Tweet" dashboard item.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [CheckAjaxRequest]
        public ActionResult RandomLastWatch()
        {
            var model = new RandomWatch
            {
                AjaxRouteAlias = Constants.AjaxRouteAliases.RandomWatched
            };

            return PartialView(model);
        }
    }
}