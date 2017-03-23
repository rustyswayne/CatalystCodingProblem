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
        /// <inheritdoc />
        [DataMember]
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public string Slug { get; internal set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty(PropertyName = "birthDay")]
        public DateTime Birthday { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty(PropertyName = "photo")]
        public string Photo { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ExtendedDataCollection"/>.
        /// </summary>
        [DataMember]
        [JsonProperty(PropertyName = "extendedData")]
        public ExtendedDataCollection ExtendedData { get; internal set; }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        [DataMember]
        [JsonProperty(PropertyName = "addresses")]
        public IList<IAddress> Addresses { get; internal set; }
    }
}