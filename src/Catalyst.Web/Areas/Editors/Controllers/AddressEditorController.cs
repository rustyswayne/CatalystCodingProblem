namespace Catalyst.Web.Areas.Editors.Controllers
{
    using System.Web.Mvc;

    using Catalyst.Core.Controllers;

    /// <summary>
    /// Controller responsible for editing person address information.
    /// </summary>
    public class AddressEditorController : CatalystControllerBase
    {

        public ActionResult Editor()
        {
            return View();
        }
    }
}