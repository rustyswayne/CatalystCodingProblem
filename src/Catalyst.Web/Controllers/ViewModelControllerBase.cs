namespace Catalyst.Web.Controllers
{
    using System.Web.Mvc;

    using Catalyst.Web.Models;
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
        /// <typeparam name="TModel">
        /// The type of the model
        /// </typeparam>
        /// <returns>
        /// The <see cref="TModel"/>.
        /// </returns>
        protected virtual TModel GetViewModel<TModel>() where TModel : ViewModelBase, new()
        {
            var current = Request.Url != null ? Request.RawUrl : string.Empty;

            return new TModel
            {
                CurrentTab = new NavTab { IsCurrent = true, Target = "_self", Url = current }
            };
        }
    }
}