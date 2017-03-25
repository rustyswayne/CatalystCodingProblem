namespace Catalyst.Web.Models.Dashboard
{
    using System;

    /// <summary>
    /// Model for dashboard item that shows a randomly watched person.
    /// </summary>
    public class RandomWatch : DashboardItemBase
    {
        /// <summary>
        /// The title.
        /// </summary>
        public override string Title => "Random Watched Person";

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = "No People watched";

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        public string Url { get; set; } = Constants.PeopleRoute;

        /// <summary>
        /// Gets or sets the photo url.
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Gets or sets the birth day.
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}