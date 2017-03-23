namespace Catalyst.Core.Data.Context
{
    using System;
    using System.Data.Entity;

    using Catalyst.Core.Data.Mapping;
    using Catalyst.Core.Logging;
    using Catalyst.Core.Models.Dto;

    /// <summary>
    /// Represents a database context for the Catalyst Coding Problem.
    /// </summary>
    public class CatalystDbContext : DbContext, ICatalystDbContext
    {
        /// <summary>
        /// The register for the model type configurations.
        /// </summary>
        private readonly IMappingConfigurationRegister _register;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalystDbContext"/> class.
        /// </summary>
        public CatalystDbContext()
            : this(Constants.Database.ConnectionStringName)
        {
            // Enables Lazy Loading of relationships
            Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalystDbContext"/> class.
        /// </summary>
        /// <param name="nameOrConnectionString">
        /// The name or connection string.
        /// </param>
        public CatalystDbContext(string nameOrConnectionString)
            : this(nameOrConnectionString, new DbMappingRegister(Logger.CreateWithDefaultLog4NetConfiguration()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalystDbContext"/> class.
        /// </summary>
        /// <param name="nameOrConnectionString">
        /// The name or connection string.
        /// </param>
        /// <param name="register">
        /// The register.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws if the register is null
        /// </exception>
        internal CatalystDbContext(string nameOrConnectionString, IMappingConfigurationRegister register)
            : base(nameOrConnectionString)
        {                   
            if (register == null) throw new ArgumentNullException(nameof(register));

            _register = register;
            
        }

        /// <inheritdoc />
        public DbSet<PersonDto> People { get; set; }

        /// <inheritdoc />
        public DbSet<AddressDto> Addresses { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            foreach (var configuration in _register.GetInstantiations())
            {
                modelBuilder.Configurations.Add(configuration);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}