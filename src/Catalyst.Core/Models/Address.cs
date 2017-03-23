namespace Catalyst.Core.Models
{
    using System;
    using System.Runtime.Serialization;

    using Catalyst.Core.Models.Entity;

    using Newtonsoft.Json;

    /// <inheritdoc />
    [Serializable]
    [DataContract(IsReference = true)]
    internal class Address : EntityBase, IAddress
    {
        /// <inheritdoc />
        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("address2")]
        public string Address2 { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}