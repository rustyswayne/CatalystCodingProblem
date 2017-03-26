namespace Catalyst.Web.Areas.Editors.Controllers
{
    using System.Web.Mvc;

    using Catalyst.Core;
    using Catalyst.Core.Controllers;
    using Catalyst.Core.Models.Domain;
    using Catalyst.Core.Models.PropData;
    using Catalyst.Core.Mvc;
    using Catalyst.Web.Areas.Editors.Models;

    /// <summary>
    /// The interest editor controller.
    /// </summary>
    public class InterestEditorController : PropertyEditorControllerBase<InterestList, InterestListEditor>
    {
        /// <inheritdoc />
        [ChildActionOnly]
        public override ActionResult Editor(Person person)
        {
            var model = new InterestListEditor($"{person.FullName()} Interests")
                {
                    PersonId = person.Id,
                    InterestList = person.GetPropertyValue<InterestList>(true),
                    ReturnUrl = person.Url(Web.Constants.PersonRoute)
                };


            return View(model);
        }


        /// <inheritdoc />
        [HttpPost]
        public override ActionResult Save(InterestListEditor model)
        {
            var person = Services.Person.Get(model.PersonId);

            if (Request.IsAjaxRequest())
            {
                var editor = new InterestListEditor($"{person.FullName()} Interests")
                {
                    PersonId = person.Id,
                    InterestList = person.GetPropertyValue<InterestList>(true),
                    ReturnUrl = person.Url(Web.Constants.PersonRoute)
                };

                return View("Editor", editor);
            }

            return Redirect(model.ReturnUrl);
        }

    }
}