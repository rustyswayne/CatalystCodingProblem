﻿namespace Catalyst.Core
{
    using System;

    using Catalyst.Core.DI;
    using Catalyst.Core.Models.Domain;
    using Catalyst.Core.Models.PropData;
    using Catalyst.Core.ValueConverters;

    /// <summary>
    /// Extension methods for extended properties.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Gets the value converter.
        /// </summary>
        /// <param name="prop">
        /// The <see cref="IExtendedProperty"/>.
        /// </param>
        /// <returns>
        /// The <see cref="IPropertyValueConverter"/>.
        /// </returns>
        public static IPropertyValueConverter Converter(this IExtendedProperty prop)
        {
            return Active.ValueConverterRegister.GetInstanceFor(prop);
        }

        /// <summary>
        /// The get property value.
        /// </summary>
        /// <param name="prop">
        /// The prop.
        /// </param>
        /// <typeparam name="TValue">
        /// The type of the value
        /// </typeparam>
        /// <returns>
        /// The <see cref="TValue"/>.
        /// </returns>
        /// <exception cref="InvalidCastException">
        /// Throws an exception if the type of the model 
        /// </exception>
        public static TValue GetPropertyValue<TValue>(this IExtendedProperty prop) 
            where TValue : class, IPropertyValueModel, new()
        {
            var converter = prop.Converter();
            if (converter.ModelType == typeof(TValue))
            {
                return converter.GetPropertyValue<TValue>();
            }

            var invalid = new InvalidCastException($"Cannot cast {converter.ModelType.FullName} to {typeof(TValue).FullName}");
            Active.Logger.Error(typeof(Extensions), "Invalid cast", invalid);
            throw invalid;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="prop">
        /// The <see cref="IExtendedProperty"/>.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object GetValue(this IExtendedProperty prop)
        {
            return prop.Converter().GetValue();
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="prop">
        /// The <see cref="IExtendedProperty"/>.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void SetValue(this IExtendedProperty prop, object value)
        {
            prop.Converter().SetValue(value);
        }
    }
}