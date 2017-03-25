namespace Catalyst.Core.Services
{
    using System.Collections.Generic;

    using Catalyst.Core.Models.Domain;

    /// <summary>
    /// Represents a service for querying people.
    /// </summary>
    public interface IPersonQueryService
    {
        /// <summary>
        /// The get recently updated.
        /// </summary>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{Person}"/>.
        /// </returns>
        IEnumerable<Person> GetRecentlyUpdated(int count = 5);


    }
}