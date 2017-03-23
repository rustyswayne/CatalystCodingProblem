namespace Catalyst.Core.Factories
{
    using Catalyst.Core.Models.Dto;
    using Catalyst.Core.Models.Entity;

    /// <summary>
    /// Represents a factory for converting domain (data) models to business models.
    /// </summary>
    /// <typeparam name="TDto">
    /// The type of the <see cref="IDto"/>
    /// </typeparam>
    /// <typeparam name="TEntity">
    /// The type of the <see cref="EntityBase"/>
    /// </typeparam>
    /// <remarks>
    /// If this 
    /// </remarks>
    internal interface IEntityFactory<TDto, TEntity>
        where TDto : IDto, new()
        where TEntity : EntityBase
    {
        /// <summary>
        /// Builds the <see cref="IDto"/>.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="TDto"/>.
        /// </returns>
        TDto BuildDto(TEntity entity);

        /// <summary>
        /// Builds the <see cref="EntityBase"/>.
        /// </summary>
        /// <param name="dto">
        /// The DTO.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity BuildEntity(TDto dto);
    }
}