namespace Catalyst.Web.Areas.Admin
{
    using System.Web.Mvc;

    /// <summary>
    /// Represents the admin area registration.
    /// </summary>
    public class AdminAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// Gets the area name.
        /// </summary>
        public override string AreaName => "Admin";

        /// <inheritdoc />
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}