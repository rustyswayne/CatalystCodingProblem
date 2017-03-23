namespace Catalyst.Core.Models.Entity
{
    using System;

    /// <summary>
    /// Represents an entity.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the id of the Entity.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets or sets the date the entity was last updated.
        /// </summary>                                                             s
        DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the initial creation date of the entity record.
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Returns a value indicating whether or the Identity (Id) has been set.
        /// </summary>
        /// <returns>
        /// A value indicating whether or not this entity has an identity (id)
        /// </returns>
        /// <remarks>
        /// Used to determine add or update operations
        /// </remarks>
        bool HasIdentity();

        /// <summary>
        /// Method to call on entity saved when first added
        /// </summary>
        void AddingEntity();


        /// <summary>
        /// Method to call on entity saved/updated
        /// </summary>
        void UpdatingEntity();
    }
}