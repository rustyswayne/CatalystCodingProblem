namespace Catalyst.Core.Services
{
    using Catalyst.Core.Models;

    /// <summary>
    /// Represents a service that manages <see cref="IPerson"/> entities.
    /// </summary>
    public interface IPersonService : ISimpleDbContextCrudService<IPerson>
    {
        /// <summary>
        /// Gets a <see cref="IPerson"/> by it's slug.
        /// </summary>
        /// <param name="slug">
        /// The slug.
        /// </param>
        /// <returns>
        /// The <see cref="IPerson"/>.
        /// </returns>
        IPerson GetBySlug(string slug);
    }
}