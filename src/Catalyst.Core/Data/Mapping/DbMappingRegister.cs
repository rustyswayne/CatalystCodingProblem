namespace Catalyst.Core.Data.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Reflection;

    using Catalyst.Core.Logging;

    /// <summary>
    /// A register for database mapping types.
    /// </summary>
    internal class DbMappingRegister : IMappingConfigurationRegister
    {
        /// <summary>
        /// The <see cref="Type"/>s registered.
        /// </summary>
        private readonly HashSet<Type> _types = new HashSet<Type>();

        /// <summary>
        /// The <see cref="ILogger"/>.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbMappingRegister"/> class.
        /// </summary>
        /// <param name="logger">
        /// The <see cref="ILogger"/>.
        /// </param>
        public DbMappingRegister(ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _logger = logger;
            this.Initialize();
        }


        /// <summary>
        /// The instance types.
        /// </summary>
        public IEnumerable<Type> InstanceTypes => _types;

        /// <summary>
        /// Gets the instantiated instances.
        /// </summary>
        /// <returns>
        /// The collection of instantiated builder configurations.
        /// </returns>
        public IEnumerable<dynamic> GetInstantiations()
        {
            return InstanceTypes.Select(Activator.CreateInstance);
        }

        /// <summary>
        /// Initializes the registry.
        /// </summary>
        public void Initialize()
        {
            _logger.Info<DbMappingRegister>("Initializing");

            var alltypes =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(type => !type.Namespace.IsNullOrWhiteSpace() && 
                                type.BaseType != null && 
                                type.BaseType.IsGenericType);

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(type => !string.IsNullOrEmpty(type.Namespace))
                        .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                        && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)).ToArray();


            _logger.Info<DbMappingRegister>($"Found {typesToRegister.Count()} types to register");

            foreach (var t in typesToRegister)
            {
                _logger.Info<DbMappingRegister>($"Adding {t.FullName} to registry");
                _types.Add(t);
            }

            _logger.Info<DbMappingRegister>("Completed adding types to register");
        }
    }
}