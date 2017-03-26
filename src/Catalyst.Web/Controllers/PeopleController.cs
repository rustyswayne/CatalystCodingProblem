namespace Catalyst.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Catalyst.Core;
    using Catalyst.Core.Logging;
    using Catalyst.Web.Models;

    /// <summary>
    /// The person controller.
    /// </summary>
    public class PeopleController : ViewModelControllerBase
    {
        /// <inheritdoc />
        public override ActionResult Index()
        {
            var model = GetViewModel<PeopleList>("About this page");
            model.CurrentTab.Title = "People";

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

            var model = GetViewModel<PersonDetail>($"About {person.FullName()} Details");
            model.CurrentTab.Title = person.FullName();
            model.Person = person;


            return View("PersonDetails", model);
        }

        /// <summary>
        /// Toggles whether or not a person is watched.
        /// </summary>
        /// <param name="id">
        /// The person's id.
        /// </param>
        /// <param name="r">
        /// The current page route.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult ToggleWatched(Guid id, string r)
        {
            var person = Services.Person.Get(id);

            if (person == null)
            {
                var nullRef = new NullReferenceException("Person record was null in ToggleWatched");
                Logger.Error<PeopleController>("Person not found", nullRef);
                throw nullRef;
            }

            person.Watch = !person.Watch;
            Services.Person.Save(person);

            return Redirect(r);
        }
    }
}