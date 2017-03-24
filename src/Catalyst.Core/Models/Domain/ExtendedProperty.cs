namespace Catalyst.Core.Models.Domain
{
    /// <summary>
    /// Represents an extended property
    /// </summary>
    public class ExtendedProperty : EntityBase, IExtendedProperty
    {
        /// <inheritdoc />
        public string ConverterAlias { get; set; }

        /// <inheritdoc />
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the person associated with the property.
        /// </summary>
        /// <remarks>
        /// Foreign key
        /// </remarks>
        public virtual Person Person { get; set; }
    }
}