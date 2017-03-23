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
        /// <summary>
        /// Stores the UTC create date.
        /// </summary>
        private DateTime? _createDate;

        /// <summary>
        /// Stores the UTC update date.
        /// </summary>
        private DateTime? _updateDate;

        /// <inheritdoc />
        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; internal set; }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty(PropertyName = "updateDate")]
        public DateTime UpdateDate
        {
            get
            {
                if (!_updateDate.HasValue)
                {
                    _updateDate = DateTime.UtcNow;
                }

                return _updateDate.Value;
            }

            set
            {
                _updateDate = value.ToUniversalTime();
            }
        }

        /// <inheritdoc />
        [DataMember]
        [JsonProperty(PropertyName = "createDate")]
        public DateTime CreateDate
        {
            get
            {
                if (!_createDate.HasValue)
                {
                    _createDate = DateTime.UtcNow;
                }

                return _createDate.Value;
            }

            set
            {
                _createDate = value.ToUniversalTime();
            }
        }

        /// <inheritdoc />
        public virtual bool HasIdentity()
        {
            return !Id.Equals(Guid.Empty);
        }

        /// <summary>
        /// Method to call on entity saved when first added
        /// </summary>
        public virtual void AddingEntity()
        {
            if (Id == Guid.Empty) Id = GuidComb.GenerateComb(); 

            CreateDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
        }


        /// <summary>
        /// Method to call on entity saved/updated
        /// </summary>
        public virtual void UpdatingEntity()
        {
            UpdateDate = DateTime.UtcNow;
        }
    }
}