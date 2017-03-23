namespace Catalyst.Core.Models.Entity
{
    using System;
    using System.Runtime.Serialization;

    using Catalyst.Core.Data;

    using Newtonsoft.Json;

    /// <inheritdoc />
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class EntityBase : IEntity
    {
        /// <inheritdoc />
        [DataMember]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("updateDate")]
        public DateTime UpdateDate { get; set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty("createDate")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Method to call on entity saved when first added
        /// </summary>
        internal virtual void AddingEntity()
        {
            if (Id == Guid.Empty) Id = GuidComb.GenerateComb(); 

            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }


        /// <summary>
        /// Method to call on entity saved/updated
        /// </summary>
        internal virtual void UpdatingEntity()
        {
            UpdateDate = DateTime.Now;
        }
    }
}