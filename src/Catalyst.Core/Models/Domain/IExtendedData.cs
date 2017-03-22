namespace Catalyst.Core.Models.Domain
{
    /// <summary>
    /// Represents an entity with an ExtendedData (JSON) field.
    /// </summary>
    internal interface IExtendedData
    {
        /// <summary>
        /// Gets or sets the extended data (JSON).
        /// </summary>
        string ExtendedData { get; set; }
    }
}