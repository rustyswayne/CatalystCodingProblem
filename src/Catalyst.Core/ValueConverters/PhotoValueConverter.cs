namespace Catalyst.Core.ValueConverters
{
    using Catalyst.Core.Models;
    using Catalyst.Core.Models.Domain;
    using Catalyst.Core.Models.PropData;

    /// <summary>
    /// Represents a property value converter for <see cref="Photo"/>.
    /// </summary>
    [ConverterAlias(Constants.ExtendedProperties.PhotoConverterAlias)]
    public class PhotoValueConverter : PropertyValueConverterBase<Photo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoValueConverter"/> class.
        /// </summary>
        /// <param name="prop">
        /// The prop.
        /// </param>
        public PhotoValueConverter(IExtendedProperty prop)
            : base(prop)
        {
        }
    }
}