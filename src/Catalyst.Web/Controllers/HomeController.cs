﻿namespace Catalyst.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using Catalyst.Core;
    using Catalyst.Web.Models;
    using Catalyst.Web.Models.Dashboard;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : ViewModelControllerBase
    {
        /// <summary>
        /// The default action.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public override ActionResult Index()
        {
            var model = GetViewModel<Home>("Requirements");

            model.CurrentTab.Title = "Home";
            model.Content.Notes = "Recieved view email";

            return View(model);
        }
    }
}