namespace Catalyst.Core.ValueConverters
{
    using Catalyst.Core.Models.Domain;
    using Catalyst.Core.Models.PropData;

    /// <summary>
    /// Represents a property value converter for <see cref="GitHubFeed"/>.
    /// </summary>
    [ConverterAlias(Constants.ExtendedProperties.GitHubFeedConverterAlias)]
    public class GitHubFeedValueConverter : PropertyValueConverterBase<GitHubFeed>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubFeedValueConverter"/> class.
        /// </summary>
        /// <param name="prop">
        /// The prop.
        /// </param>
        public GitHubFeedValueConverter(IExtendedProperty prop)
            : base(prop)
        {
        }
    }
}