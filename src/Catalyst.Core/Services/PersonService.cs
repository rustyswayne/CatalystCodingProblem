namespace Catalyst.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Catalyst.Core.Caching;
    using Catalyst.Core.Data.Context;
    using Catalyst.Core.Factories;
    using Catalyst.Core.Logging;
    using Catalyst.Core.Models;

    /// <inheritdoc />
    internal class PersonService : CatalystDbContextServiceBase<IPerson>, IPersonService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="context">
        /// The <see cref="ICatalystDbContext"/>.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ICacheManager"/>.
        /// </param>
        /// <param name="logger">
        /// The <see cref="ILogger"/>.
        /// </param>
        public PersonService(ICatalystDbContext context, ICacheManager cache, ILogger logger)
            : base(context, cache, logger)
        {
        }

        /// <inheritdoc />
        public IEnumerable<IPerson> GetAll()
        {
            // fixme - quick hack to simply query all.
            // this should have a check for cached items based on cached item count and count.
            var factory = new PersonFactory();

            // TODO - fix this Lazy hack
            var dtos = Db.People.ToArray();

            return dtos.Select(peep => factory.BuildEntity(peep));
        }


        /// <inheritdoc />
        public IPerson GetBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int Count()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Save(IPerson entity)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Delete(IPerson entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the entity from the context.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IPerson"/>.
        /// </returns>
        protected override IPerson PerformGet(Guid id)
        {
            var dto = Db.People.Find(id);
            if (dto == null) return null;

            var factory = new PersonFactory();
            return factory.BuildEntity(dto);
        }
    }
}