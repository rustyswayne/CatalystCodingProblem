namespace Catalyst.Core.Models.PropData
{
    /// <summary>
    /// Represents a GitHub commit feed.
    /// </summary>
    // ReSharper disable once StyleCop.SA1650
    public class GitHubFeed : IPropertyValueModel
    {
        /// <summary>
        /// Gets or sets the repository url.
        /// </summary>
        public string RepositoryUrl { get; set; }
    }
}