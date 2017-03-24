namespace Catalyst.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using Catalyst.Core;
    using Catalyst.Web.Models;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : CatalystControllerBase
    {
        /// <summary>
        /// The default action.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public override ActionResult Index()
        {

            var model = GetViewModel<Home>();
            model.CurrentTab.Title = "Home";
            model.BodyText = GetReadmeMarkdown();
            
            return View(model);
        }

        /// <summary>
        /// Reads the contents of the README.md file (in App_Data), converts to html and returns.
        /// </summary>
        /// <returns>
        /// The <see cref="IHtmlString"/>.
        /// </returns>
        /// <remarks>
        /// This should be moved to a service or helper
        /// </remarks>
        private IHtmlString GetReadmeMarkdown()
        {
            const string MdPath = "~/App_Data/README.md";

            var path = Server.MapPath(MdPath);

            if (System.IO.File.Exists(path))
            {
                var md = System.IO.File.ReadAllText(Server.MapPath(MdPath));
                if (!md.IsNullOrWhiteSpace())
                {
                    return MvcHtmlString.Create(CommonMark.CommonMarkConverter.Convert(md));
                }
            }

            return MvcHtmlString.Empty;
        }
    }
}