namespace Catalyst.Web.Models
{
    using System.Web;

    /// <summary>
    /// Represents the home view model.
    /// </summary>
    public class Home : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the body text.
        /// </summary>
        public IHtmlString BodyText { get; set; }
    }
}