namespace Catalyst.Web.Areas.Editors.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Catalyst.Core;
    using Catalyst.Core.Controllers;
    using Catalyst.Core.Models.Domain;
    using Catalyst.Core.Models.PropData;
    using Catalyst.Web.Areas.Editors.Models;

    /// <summary>
    /// Property editor controller responsible for <see cref="SocialLinks"/>.
    /// </summary>
    public class SocialLinksEditorController : PropertyEditorControllerBase<SocialLinks>
    {
        /// <summary>
        /// Responsible for rendering the editor.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ChildActionOnly]
        public ActionResult Editor(Person person)
        {
            var value = person.GetPropertyValue<SocialLinks>(true);

            var property = person.GetProperty(ConverterMapping.ConverterAlias);

            var model = new SocialLinksEditor("Edit Social Links")
                {
                    PersonId = person.Id,
                    PropertyId = property != null ? property.Id : Guid.Empty,
                    Facebook = value.Facebook,
                    Twitter = value.Twitter,
                    LinkedIn = value.LinkedIn,
                    GooglePlus = value.GooglePlus,
                    YouTube = value.YouTube,
                    ReturnUrl = person.Url(Web.Constants.PersonRoute)
                };

            return View(model);
        }

        /// <summary>
        /// Saves the property value.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSocialLinks(SocialLinksEditor model)
        {
            var person = Services.Person.Get(model.PersonId, false);

            var social = person.GetPropertyValue<SocialLinks>(true);
            social.Facebook = model.Facebook;
            social.GooglePlus = model.GooglePlus;
            social.Twitter = model.Twitter;
            social.LinkedIn = model.LinkedIn;
            social.YouTube = model.YouTube;

            var prop = person.Properties.SingleOrDefault(x => x.ConverterAlias == ConverterMapping.ConverterAlias);
            if (prop == null)
            {
                prop = new ExtendedProperty { ConverterAlias = ConverterMapping.ConverterAlias };
                prop.SetValue(social);
                person.Properties.Add(prop);
            }
            else
            {
                prop.SetValue(social);
            }

            Services.Person.Save(person, true);

            return Redirect(model.ReturnUrl);
        }

    }
}