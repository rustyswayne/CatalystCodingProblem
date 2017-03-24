namespace Catalyst.Core.ValueConverters
{
    using Catalyst.Core.Models.Domain;
    using Catalyst.Core.Models.PropData;

    /// <summary>
    /// Represents a property value converter.
    /// </summary>
    /// <typeparam name="TValue">
    /// The type of the value
    /// </typeparam>
    public interface IPropertyValueConverter<TValue> : IPropertyValueConverter
        where TValue : class, IPropertyValueModel, new()
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>
        /// The <see cref="TValue"/>.
        /// </returns>
        TValue GetValue();

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        void SetValue(TValue value);
    }

    /// <summary>
    /// Represents a property value converter.
    /// </summary>
    public interface IPropertyValueConverter
    {
        /// <summary>
        /// Gets the property.
        /// </summary>
        IExtendedProperty Property { get; }

    }
}