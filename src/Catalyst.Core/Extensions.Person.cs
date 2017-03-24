namespace Catalyst.Core
{
    using System;
    using System.Linq;
    using System.Threading;

    using Catalyst.Core.DI;
    using Catalyst.Core.Models.Domain;
    using Catalyst.Core.Models.PropData;

    /// <summary>
    /// Extension methods related to <see cref="IEntity"/> models.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// The full name.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string FullName(this IPerson person)
        {
            var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase($"{person.FirstName} {person.LastName}");
        }

        /// <summary>
        /// Gets the Url for the person.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="baseRoute">
        /// The base Route.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Url(this IPerson person, string baseRoute = "")
        {
            return $"{baseRoute}/{person.Slug}".EnsureStartsAndEndsWith('/');
        }

        /// <summary>
        /// Checks if an extended property exists.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="converterAlias">
        /// The converter alias.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the extended property exists.
        /// </returns>
        public static bool HasExtendedProperty(this IPerson person, string converterAlias)
        {
            return person.Properties.Any(x => x.ConverterAlias.Equals(converterAlias, System.StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Gets a property by it's alias.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="converterAlias">
        /// The converter alias.
        /// </param>
        /// <returns>
        /// The <see cref="IExtendedProperty"/>.
        /// </returns>
        public static IExtendedProperty GetProperty(this IPerson person, string converterAlias)
        {
            return person.Properties.FirstOrDefault(x => x.ConverterAlias.Equals(converterAlias, System.StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="converterAlias">
        /// The converter alias.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object GetValue(this IPerson person, string converterAlias)
        {
            return person.GetProperty(converterAlias).Converter().GetValue();
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="converterAlias">
        /// The converter alias.
        /// </param>
        /// <typeparam name="TValue">
        /// The type of the value
        /// </typeparam>
        /// <returns>
        /// The <see cref="TValue"/>.
        /// </returns>
        public static TValue GetPropertyValue<TValue>(this IPerson person, string converterAlias)
            where TValue : class, IPropertyValueModel, new()
        {
            return person.GetProperty(converterAlias).Converter().GetPropertyValue<TValue>();
        }

        /// <summary>
        /// Adds an address to <see cref="IPerson"/>.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="address">
        /// The address.
        /// </param>
        public static void AddAddress(this IPerson person, IAddress address)
        {
            var adr = new Address
            {
                Name = address.Name,
                Address1 = address.Address1,
                Address2 = address.Address2,
                Locality = address.Locality,
                Region = address.Region,
                PostalCode = address.PostalCode,
                CountryCode = address.CountryCode
            };

            person.Addresses.Add(adr);
        }

        /// <summary>
        /// Generates a slug for the person.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="attempt">
        /// The attempt.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        internal static string GenerateSlug(this IPerson person, int attempt = 0)
        {
            var baseSlug = $"{person.FirstName} {person.LastName}".ConvertToSlug().ToLowerInvariant();
            return attempt == 0 ? baseSlug : $"{baseSlug}-{attempt}";
        }
    }
}
