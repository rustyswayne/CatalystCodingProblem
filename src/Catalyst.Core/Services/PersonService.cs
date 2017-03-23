namespace Catalyst.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Catalyst.Core.Caching;
    using Catalyst.Core.Data.Context;
    using Catalyst.Core.Factories;
    using Catalyst.Core.Logging;
    using Catalyst.Core.Models;
    using Catalyst.Core.Models.Dto;

    using LightInject;

    /// <inheritdoc />
    internal class PersonService : CatalystDbContextServiceBase<IPerson, PersonDto>, IPersonService
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
        public PersonService([Inject(Constants.Database.ConnectionStringName)]ICatalystDbContext context, ICacheManager cache, ILogger logger)
            : base(context, cache, logger)
        {
        }

        /// <summary>
        /// The <see cref="DbSet{PersonDto}"/>.
        /// </summary>
        protected override DbSet<PersonDto> Db => DbContext.People;

        /// <inheritdoc />
        public IPerson Create(string firstName, string lastName, DateTime birthDay)
        {
            return new Person { FirstName = firstName, LastName = lastName, Birthday = birthDay };
        }

        ///// <inheritdoc />
        //public IEnumerable<IPerson> GetAll()
        //{
        //    // fixme - quick hack to simply query all.
        //    // this should have a check for cached items based on cached item count and count.
        //    var factory = new PersonFactory();

        //    return Db.ToArray().Select(peep => factory.BuildEntity(peep));
        //}


        /// <inheritdoc />
        public IPerson GetBySlug(string slug)
        {
            var factory = GetFactory();
            var dto = Db.FirstOrDefault(x => x.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase));

            return dto != null ? factory.BuildEntity(dto) : null;
        }


        /// <summary>
        /// Get's a unique slug for the <see cref="IPerson"/>.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        internal string GetUniqueSlug(IPerson person)
        {
            var attempt = 0;
            while (!EnsureUniqueSlug(person.GenerateSlug(attempt)))
            {
                attempt++;
            }

            return person.GenerateSlug(attempt);
        }

        /// <summary>
        /// Ensures the slug is unique.
        /// </summary>
        /// <param name="slug">
        /// The slug.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        internal bool EnsureUniqueSlug(string slug)
        {
            return Db.FirstOrDefault(x => x.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase)) == null;
        }

        /// <inheritdoc />
        protected override void PerformAdd(IPerson entity)
        {
            ((Person)entity).Slug = GetUniqueSlug(entity);
            base.PerformAdd(entity);
        }

        /// <summary>
        /// Gets the person factory.
        /// </summary>
        /// <returns>
        /// The <see cref="PersonFactory"/>.
        /// </returns>
        protected override EntityFactoryBase<PersonDto, IPerson> GetFactory()
        {
            return new PersonFactory();
        }
    }
}