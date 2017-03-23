namespace Catalyst.Core.Models.Dto
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