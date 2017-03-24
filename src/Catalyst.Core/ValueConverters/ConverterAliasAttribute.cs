﻿namespace Catalyst.Core.ValueConverters
{
    using System;

    using Catalyst.Core.Models.Domain;

    /// <summary>
    /// Represents an attribute that associates property value converters with <see cref="IExtendedProperty"/> values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ConverterAliasAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterAliasAttribute"/> class.
        /// </summary>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Alias is required
        /// </exception>
        public ConverterAliasAttribute(string alias)
        {
            if (alias.IsNullOrWhiteSpace()) throw new ArgumentNullException(nameof(alias));
            ConverterAlias = alias;
        }

        /// <summary>
        /// Gets the converter alias.
        /// </summary>
        /// <remarks>
        /// This MUST match the "ConverterAlias" property associated with the <see cref="IExtendedProperty"/> value
        /// </remarks>
        public string ConverterAlias { get; }
    }
}