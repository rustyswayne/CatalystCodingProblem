namespace Catalyst.Core.Factories
{
    using Catalyst.Core.Models.Dto;
    using Catalyst.Core.Models.Entity;

    /// <summary>
    /// Represents a factory for converting domain (data) models to business models.
    /// </summary>
    /// <typeparam name="TDto">
    /// The type of the DTO
    /// </typeparam>
    /// <typeparam name="TEntity">
    /// The type of the entity
    /// </typeparam>
    internal abstract class EntityFactoryBase<TDto, TEntity> : IEntityFactory<TDto, TEntity>
        where TDto : IDto, new()
        where TEntity : IEntity
    {
        /// <inheritdoc />
        public TDto BuildDto(TEntity entity)
        {
            var dto = PerformBuildDTo(entity);
            return dto;
        }

        /// <inheritdoc />
        public TEntity BuildEntity(TDto dto)
        {
            var entity = PerformBuildEntity(dto);

            return entity;
        }

        /// <summary>
        /// Performs the work of building the DTO object.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="TDto"/>.
        /// </returns>
        protected abstract TDto PerformBuildDTo(TEntity entity);

        /// <summary>
        /// Performs the work of building the entity object.
        /// </summary>
        /// <param name="dto">
        /// The dto.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        protected abstract TEntity PerformBuildEntity(TDto dto);
    }
}