namespace Catalyst.Web.Controllers
{
    using System.Web.Mvc;

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

        //[ChildActionOnly]
        //public ActionResult CountriesSnapshot()
        //{
            
        //}
    }
}