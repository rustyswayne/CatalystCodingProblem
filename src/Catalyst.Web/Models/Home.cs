namespace Catalyst.Web.Models
{
    using Catalyst.Web.Models.Boxes;
    using Catalyst.Web.Models.Shared;

    /// <summary>
    /// Represents the home view model.
    /// </summary>
    public class Home : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Home"/> class.
        /// </summary>
        public Home()
        {
            Meta = new Meta
            {
                PageTitle = "Home - People Problem",
                Description = "Reads contents of Readme.md file and displays as content"
            };
        }

        /// <summary>
        /// Gets or sets the body text.
        /// </summary>
        public ContentBox Instructions { get; set; }
    }
}