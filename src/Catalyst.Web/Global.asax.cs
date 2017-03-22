namespace Catalyst.Web
{
    using System;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Catalyst.Web.Boot;

    using LightInject;

    /// <summary>
    /// Global application handler.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Handles the Application Start.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The <see cref="EventArgs"/>.
        /// </param>
        private void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Instantiate the Service Container
            var container = new ServiceContainer();
            container.EnableAnnotatedConstructorInjection();
            container.EnableAnnotatedPropertyInjection();

            // Bootstrap!
            var loader = new WebBoot(container);
            loader.Boot();
        }
    }
}