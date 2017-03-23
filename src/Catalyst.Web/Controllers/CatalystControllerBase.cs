namespace Catalyst.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Catalyst.Core.DI;
    using Catalyst.Core.Services;

    /// <summary>
    /// Represents a base MVC controller for the catalyst context.
    /// </summary>
    public abstract class CatalystControllerBase : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalystControllerBase"/> class.
        /// </summary>
        protected CatalystControllerBase()
            : this(Active.Services)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalystControllerBase"/> class.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws an exception if the <see cref="IServiceContext"/> is null    
        /// </exception>
        protected CatalystControllerBase(IServiceContext services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            Services = services;
        }

        /// <summary>
        /// Gets the <see cref="IServiceContext"/>.
        /// </summary>
        protected IServiceContext Services { get; }

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
    }
}