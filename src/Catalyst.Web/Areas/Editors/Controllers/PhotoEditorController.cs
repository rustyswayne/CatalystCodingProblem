namespace Catalyst.Web.Areas.Editors.Controllers
{
    using System;
    using System.Web.Mvc;

    using Catalyst.Core.Controllers;
    using Catalyst.Core.Models.Domain;
    using Catalyst.Core.Models.PropData;
    using Catalyst.Core.Mvc;
    using Catalyst.Web.Areas.Editors.Models;

    /// <summary>
    /// Property editor controller responsible for <see cref="Photo"/>.
    /// </summary>
    public class PhotoEditorController : EditorControllerBase<Photo,PhotoEditor>
    {
        /// <inheritdoc />
        [HttpGet]
        [CheckAjaxRequest]
        public override ActionResult Editor(Guid id)
        {
            var person = Services.Person.Get(id);

            var model = new PhotoEditor("Photo")
            {
                PersonId = person.Id,
                PhotoUrl = person.PhotoUrl()
            };

            return View(model);
        }

        /// <inheritdoc />
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Save(PhotoEditor model)
        {
            throw new NotImplementedException();
        }
    }
}