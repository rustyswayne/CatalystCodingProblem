namespace Catalyst.Core.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Catalyst.Core.Models.Domain;

    /// <inheritdoc />
    internal partial class PersonService : IPersonQueryService
    {
        /// <inheritdoc />
        public IEnumerable<Person> GetRecentlyUpdated(int count = 5)
        {
            return this.Context.AsNoTracking()
                .OrderByDescending(x => x.UpdateDate)
                .Take(count)
                .Select(x => x.Id)
                .ToArray()
                .Select(id => Get(id));
        }
    }
}
