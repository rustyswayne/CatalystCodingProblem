namespace Catalyst.Web.Areas.Editors.Controllers
{
    using System;
    using System.Collections.Generic;
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
    public class InterestEditorController : EditorControllerBase<InterestList, InterestListEditor>
    {
        /// <inheritdoc />
        [HttpGet]
        [CheckAjaxRequest]
        public override ActionResult Editor(Guid id)
        {
            var person = Services.Person.Get(id);

            var model = new InterestListEditor("Interests")
                {
                    PersonId = person.Id,
                    InterestList =
                        person.GetPropertyValue<InterestList>(true),
                    ReturnUrl = person.Url(Web.Constants.PersonRoute)
                };

            return View(model);
        }


        /// <inheritdoc />
        [HttpPost]
        public override ActionResult Save(InterestListEditor model)
        {
            var person = Services.Person.Get(model.PersonId);

            if (ModelState.IsValid)
            {
                var interest = new Interest { Title = model.InterestName, Url = model.Url };
                var interests = person.GetPropertyValue<InterestList>(true);

                // Update the property
                // TODO - this needs to be handled in the property itself (should not 
                // need to work so hard here)
                var list = new List<Interest>();
                list.AddRange(interests.Values);
                list.Add(interest);
                interests.Values = list;

                var prop = person.GetProperty(this.ConverterMapping.ConverterAlias);

                if (prop == null)
                {
                    prop = new ExtendedProperty
                    {
                        ConverterAlias = this.ConverterMapping.ConverterAlias
                    };

                    person.Properties.Add((ExtendedProperty)prop);
                }
                           
                prop.SetValue(interests);

                Services.Person.Save(person, true);

            }


            return Redirect(model.ReturnUrl);
        }

    }
}