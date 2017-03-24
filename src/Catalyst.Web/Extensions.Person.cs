namespace Catalyst.Web
{
    using System;
    using System.Linq;

    using Catalyst.Core;
    using Catalyst.Core.Models.Domain;

    /// <summary>
    /// Extension methods for <see cref="Person"/>.
    /// </summary>
    public static partial class Extensions
    {
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
            return person.Url("person");
        }

        //// Properties

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
        /// Checks if the <c>'Photo'</c> property exists.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the <c>'Photo'</c> property exists.
        /// </returns>
        public static bool HasPhoto(this IPerson person)
        {
            return person.HasExtendedProperty(Constants.ExtendedProperties.PhotoConverterAlias);
        }

        /// <summary>
        /// Checks if the <c>'Interest List'</c> property exists.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the <c>'Interest List'</c> property exists.
        /// </returns>
        public static bool HasInterests(this IPerson person)
        {
            return person.HasExtendedProperty(Constants.ExtendedProperties.InterestListConverterAlias);
        }

        /// <summary>
        /// Checks if the <c>'GitHub Feed'</c> property exists.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the <c>'GitHub Feed'</c> property exists.
        /// </returns>
        public static bool HasGitHubFeed(this IPerson person)
        {
            return person.HasExtendedProperty(Constants.ExtendedProperties.GitHubFeedConverterAlias);
        }

        /// <summary>
        /// Checks if the <c>'Social Links'</c> property exists.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// A value indicating whether or not the <c>'Social Links'</c> property exists.
        /// </returns>
        public static bool HasSocialLinks(this IPerson person)
        {
            return person.HasExtendedProperty(Constants.ExtendedProperties.SocialLinksConverterAlias);
        }

        /// <summary>
        /// The photo url.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string PhotoUrl(this IPerson person)
        {
            throw new NotImplementedException();
        }
    }
}