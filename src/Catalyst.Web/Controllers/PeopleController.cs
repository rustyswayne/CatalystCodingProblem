namespace Catalyst.Web.Controllers
{
    using System.Web.Mvc;

    using Catalyst.Core;
    using Catalyst.Web.Models;

    /// <summary>
    /// The person controller.
    /// </summary>
    public class PeopleController : ViewModelControllerBase
    {
        /// <inheritdoc />
        public override ActionResult Index()
        {
            var model = GetViewModel<PeopleList>();
            model.CurrentTab.Title = "People";
            model.People = Services.Person.GetAll();

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

            var model = GetViewModel<PersonDetail>();
            model.CurrentTab.Title = person.FullName();
            model.Person = person;


            return View("PersonDetails", model);
        }
    }
}