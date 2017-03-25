namespace Catalyst.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using Catalyst.Core;
    using Catalyst.Web.Models;
    using Catalyst.Web.Models.Dashboard;
    using Catalyst.Web.Models.Shared;

    /// <summary>
    /// A base controller responsible for constructing view models.
    /// </summary>
    public abstract class ViewModelControllerBase : CatalystControllerBase
    {
        /// <summary>
        /// The default action.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public virtual ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Instantiates a view model.
        /// </summary>
        /// <param name="contentTitle">
        /// The title for the content box.
        /// </param>
        /// <typeparam name="TModel">
        /// The type of the model
        /// </typeparam>
        /// <returns>
        /// The <see cref="TModel"/>.
        /// </returns>
        protected virtual TModel GetViewModel<TModel>(string contentTitle = "") where TModel : ViewModelBase, new()
        {
            var current = Request.Url != null ? Request.RawUrl : string.Empty;

            return new TModel
            {
                CurrentTab = new NavTab { IsCurrent = true, Target = "_self", Url = current },
                Content = new RichText(contentTitle.IsNullOrWhiteSpace() ? typeof(TModel).Name : contentTitle)
                              {
                                  Content = GetMarkdown<TModel>()
                              }
            };
        }


        /// <summary>
        /// Reads the contents of the README.md file (in App_Data), converts to html and returns.
        /// </summary>
        /// <typeparam name="TModel">
        /// The type of the model
        /// </typeparam>
        /// <returns>
        /// The <see cref="IHtmlString"/>.
        /// </returns>
        /// <remarks>
        /// This should be moved to a service or helper
        /// </remarks>
        private IHtmlString GetMarkdown<TModel>()
        {
            var markdownPath = $"~/App_Data/Markdown/{typeof(TModel).Name}.md";

            var path = Server.MapPath(markdownPath);

            if (System.IO.File.Exists(path))
            {
                var md = System.IO.File.ReadAllText(Server.MapPath(markdownPath));
                if (!md.IsNullOrWhiteSpace())
                {
                    return MvcHtmlString.Create(CommonMark.CommonMarkConverter.Convert(md));
                }
            }

            return MvcHtmlString.Empty;
        }
    }
}