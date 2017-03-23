namespace Catalyst.Core.Models
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Xml;

    /// <summary>
    /// Represents a collection of "extended data".
    /// </summary>
    [Serializable]
    [DataContract(IsReference = true)]
    public class ExtendedDataCollection : ConcurrentDictionary<string, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedDataCollection"/> class.
        /// </summary>
        public ExtendedDataCollection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedDataCollection"/> class.
        /// </summary>
        /// <param name="pairs">
        /// The pairs.
        /// </param>
        internal ExtendedDataCollection(IEnumerable<KeyValuePair<string, string>> pairs)
        {
            Initialize(pairs);
        }

        /// <summary>
        /// Sets an extended data value.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetValue(string key, string value)
        {
            var validKey = AssertValidKey(key);
            AddOrUpdate(validKey, value, (x, y) => value);
        }

        /// <summary>
        /// Removes a value from extended data.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        public void RemoveValue(string key)
        {
            var validKey = AssertValidKey(key);
            string obj;
            TryRemove(validKey, out obj);
        }

        /// <summary>
        /// Gets a value from the collection.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetValue(string key)
        {
            var validKey = AssertValidKey(key);
            return ContainsKey(validKey) ? this[validKey] : string.Empty;
        }


        /// <summary>
        /// Ensures that a key is value.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string AssertValidKey(string key)
        {
            key = key.Replace(" ", string.Empty);
            return XmlConvert.EncodeLocalName(key);
        }

        /// <summary>
        /// Initializes the collection.
        /// </summary>
        /// <param name="pairs">
        /// The pairs.
        /// </param>
        private void Initialize(IEnumerable<KeyValuePair<string, string>> pairs)
        {
            foreach (var p in pairs)
            {
                SetValue(p.Key, p.Value);
            }
        }
    }
}