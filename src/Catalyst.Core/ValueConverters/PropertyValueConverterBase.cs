namespace Catalyst.Core.ValueConverters
{
    using System;

    using Catalyst.Core.Models.Domain;
    using Catalyst.Core.Models.PropData;

    using Newtonsoft.Json;

    /// <inheritdoc />
    public abstract class PropertyValueConverterBase<TValue> : IPropertyValueConverter
        where TValue : class, IPropertyValueModel, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyValueConverterBase{TValue}"/> class.
        /// </summary>
        /// <param name="prop">
        /// The prop.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws an exception if the property is null
        /// </exception>
        protected PropertyValueConverterBase(IExtendedProperty prop)
        {
            if (prop == null) throw new ArgumentNullException(nameof(prop));
            Property = prop;
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        public IExtendedProperty Property { get; }

        /// <inheritdoc />
        public virtual void SetValue(TValue value)
        {
            Property.Value = JsonConvert.SerializeObject(value);
        }

        /// <inheritdoc />
        public virtual TValue GetValue()
        {
            return !this.Property.Value.IsNullOrWhiteSpace()
                       ? JsonConvert.DeserializeObject<TValue>(this.Property.Value)
                       : new TValue();
        }
    }
}