namespace Catalyst.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Catalyst.Core.Models.Entity;

    using Newtonsoft.Json;

    /// <inheritdoc />
    [Serializable]
    [DataContract(IsReference = true)]
    internal class Person : EntityBase, IPerson
    {
        /// <summary>
        /// The collection of interests.
        /// </summary>
        private readonly List<string> _interests = new List<string>();

        /// <summary>
        /// Indicates if extended data has been deserialized.
        /// </summary>
        private bool _initialized = false;

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("birthDay")]
        public DateTime Birthday { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("photo")]
        public string Photo { get; set; }


        /// <summary>
        /// Gets or sets the <see cref="ExtendedDataCollection"/>.
        /// </summary>
        [DataMember]
        [JsonProperty("extendedData")]
        public ExtendedDataCollection ExtendedData { get; internal set; }

        /// <summary>
        /// Gets the interests.
        /// </summary>
        [IgnoreDataMember]
        [JsonIgnore]
        public IList<string> Interests
        {
            get
            {
                if (_initialized) return _interests;

                var raw = this.ExtendedData.GetValue(Constants.ExtendedData.Intersets);
                if (!raw.IsNullOrWhiteSpace())
                {
                    var items = JsonConvert.DeserializeObject<IEnumerable<string>>(raw);
                    _interests.AddRange(items);
                }

                _initialized = true;
                return _interests;
            }
        }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        [DataMember]
        [JsonProperty("addresses")]
        public IList<IAddress> Addresses { get; internal set; }

        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        [DataMember]
        [JsonIgnore]
        internal string Slug { get; set; }
    }
}