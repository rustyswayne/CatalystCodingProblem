namespace Catalyst.Core
{
    using System.Globalization;

    /// <summary>
    /// Extension methods for Strings.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>Inspects a string to determine if it is null or white space.</summary>
        /// <param name="str">The string to inspect.</param>
        /// <returns>A value indicating whether or not the string was null or white space.</returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return (str == null) || (str.Trim().Length == 0);
        }

        /// <summary>
        /// Inspects a string to determine if it is null or white space, if it is, will return the default value.
        /// </summary>
        /// <param name="str">
        /// The string to inspect.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <returns>
        /// The original string or the default value.
        /// </returns>
        public static string IfNullOrWhiteSpace(this string str, string defaultValue)
        {
            return str.IsNullOrWhiteSpace() ? defaultValue : str;
        }

        /// <summary>
        /// Converts an integer to an invariant formatted string
        /// </summary>
        /// <param name="str">The source string</param>
        /// <returns>The string representation of the integer</returns>
        public static string ToInvariantString(this int str)
        {
            return str.ToString(CultureInfo.InvariantCulture);
        }
    }
}
