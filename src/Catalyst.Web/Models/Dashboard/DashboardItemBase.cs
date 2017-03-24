namespace Catalyst.Web.Models.Dashboard
{
    /// <summary>
    /// Represents a base UI box model.
    /// </summary>
    public abstract class DashboardItemBase
    {
        /// <summary>
        /// Gets the box title.
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        public string Notes { get; set; }
    }
}