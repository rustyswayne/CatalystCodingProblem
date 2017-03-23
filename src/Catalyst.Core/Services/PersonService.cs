namespace Catalyst.Core.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Catalyst.Core.Caching;
    using Catalyst.Core.Data.Context;
    using Catalyst.Core.Logging;
    using Catalyst.Core.Models.Domain;

    using LightInject;

    /// <inheritdoc />
    internal class PersonService : CatalystDbContextServiceBase<Person>, IPersonService
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
        /// The <see cref="DbSet{Person}"/>.
        /// </summary>
        protected override DbSet<Person> Db => DbContext.People;

        /// <summary>
        /// The entity set name.
        /// </summary>
        protected override string EntitySetName => "Person";

        /// <inheritdoc />
        public Person Create(string firstName, string lastName, DateTime birthDay)
        {
            return new Person { FirstName = firstName, LastName = lastName, Birthday = birthDay };
        }

        /// <inheritdoc />
        public Person GetBySlug(string slug)
        {
            return Db.AsNoTracking()
                    .FirstOrDefault(x => x.Slug.Equals(slug, StringComparison.InvariantCultureIgnoreCase));
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
        protected override void PerformAdd(Person entity)
        {
            ((Person)entity).Slug = GetUniqueSlug(entity);
            base.PerformAdd(entity);
        }
    }
}