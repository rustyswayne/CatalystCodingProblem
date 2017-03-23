namespace Catalyst.Core.Services
{
    using System;

    using Catalyst.Core.Models;

    /// <summary>
    /// Represents a service that manages <see cref="IPerson"/> entities.
    /// </summary>
    public interface IPersonService : ISimpleDbContextCrudService<IPerson>
    {
        /// <summary>
        /// Creates a <see cref="IPerson"/> without saving it.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="birthDay">
        /// The birth day.
        /// </param>
        /// <returns>
        /// The <see cref="IPerson"/>.
        /// </returns>
        IPerson Create(string firstName, string lastName, DateTime birthDay);

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