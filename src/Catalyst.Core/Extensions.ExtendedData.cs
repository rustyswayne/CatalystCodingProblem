namespace Catalyst.Core
{
    using System.Collections.Generic;

    using Catalyst.Core.Models;

    using Newtonsoft.Json;

    /// <summary>
    /// Extension methods for the <see cref="ExtendedDataCollection"/>.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Utility to convert collection into easily serializable format.
        /// </summary>
        /// <param name="ed">
        /// The ed.
        /// </param>
        /// <returns>
        /// The collection of <see cref="KeyValuePair{TKey, TValue}"/>.
        /// </returns>
        internal static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this ExtendedDataCollection ed)
        {
            foreach (var key in ed.Keys)
            {
                yield return new KeyValuePair<string, string>(key, ed[key]);
            }
        }

        /// <summary>
        /// The serializes the collection to JSON.
        /// </summary>
        /// <param name="ed">
        /// The ed.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        internal static string Serialize(this ExtendedDataCollection ed)
        {
            var values = ed.AsEnumerable();

            return JsonConvert.SerializeObject(values);
        }
    }
}
