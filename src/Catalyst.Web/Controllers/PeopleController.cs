namespace Catalyst.Web.Controllers
{
    using System.Web.Mvc;

    using Catalyst.Core;
    using Catalyst.Web.Models;

    /// <summary>
    /// The person controller.
    /// </summary>
    public class PeopleController : CatalystControllerBase
    {
        /// <inheritdoc />
        public override ActionResult Index()
        {
            var model = new PeopleList
            {
                Meta =
                    {
                        PageTitle = "People List - People Problem",
                        Description = "Displays a list of all people that have been saved to the database"
                    },
                People = Services.Person.GetAll()
            };

            return View(model);
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
            if (slug.IsNullOrWhiteSpace())
            {
                return RedirectToAction("Index");
            }

            var person = Services.Person.GetBySlug(slug);
            if (person == null) return RedirectToAction("Index");

            var model = new PersonDetail
                {
                    Meta =
                    {
                        PageTitle = $"{person.FullName()} - People Problem",
                        Description = "Provides access to all records associated with a person"
                    },
                    Person = person
                };

            return View("PersonDetails", model);
        }
    }
}