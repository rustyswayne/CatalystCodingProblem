namespace Catalyst.Core
{
    using System.Threading;

    using Catalyst.Core.Models.Domain;

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
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string Url(this IPerson person)
        {
            return $"person/{person.Slug}".EnsureStartsAndEndsWith('/');
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
