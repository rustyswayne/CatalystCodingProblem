namespace Catalyst.Web.Models.Boxes
{
    using System.Web;

    /// <summary>
    /// Represents a generic content box.
    /// </summary>
    public class ContentBox : BoxBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentBox"/> class.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        public ContentBox(string title)
        {
            Title = title;
        }

        /// <inheritdoc />
        public override string Title { get; }

        /// <summary>
        /// Gets or sets the HTML content.
        /// </summary>
        public IHtmlString Content { get; set; }
    }
}