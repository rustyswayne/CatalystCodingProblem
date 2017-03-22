namespace Catalyst.Core.Data.Context
{
    using System.Data.Entity;

    using Catalyst.Core.Models.Domain;

    /// <summary>
    /// Represents a database context for the Catalyst Coding Problem.
    /// </summary>
    internal class CatalystDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalystDbContext"/> class.
        /// </summary>
        public CatalystDbContext()
            : base(Constants.Database.ConnectionStringName)
        {
            // Enables Lazy Loading of relationships
            Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// Gets or sets the people <see cref="DbSet"/>.
        /// </summary>
        public DbSet<Person> People { get; set; }

        /// <summary>
        /// Gets or sets the addresses <see cref="DbSet"/>.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }
    }
}