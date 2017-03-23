namespace Catalyst.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Catalyst.Core.Models.Entity;

    /// <summary>
    /// Represents a service based off <see cref="DbContext"/>.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of <see cref="IEntity"/>
    /// </typeparam>
    public interface ISimpleDbContextCrudService<TEntity> : IService
        where TEntity : IEntity
    {
        /// <summary>
        /// Gets the count of all entities managed by the service.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Count();

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{TEntity}"/>.
        /// </returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets an entity by it's Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity Get(Guid id);

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Save(TEntity entity);

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Delete(TEntity entity);
    }
}