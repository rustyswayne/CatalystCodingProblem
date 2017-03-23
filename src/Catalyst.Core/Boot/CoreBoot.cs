namespace Catalyst.Core.Boot
{
    using System;

    using Catalyst.Core.DI;
    using Catalyst.Core.DI.Compositions;
    using Catalyst.Core.Logging;

    using LightInject;

    /// <summary>
    /// Application boot strap for the Catalyst 'People Search Coding Problem'
    /// </summary>
    /// <remarks>
    /// Setup for singletons and DI.
    /// </remarks>
    internal class CoreBoot : IBoot
    {
        /// <summary>
        /// The <see cref="IServiceContainer"/>.
        /// </summary>
        private readonly IServiceContainer _container;

        /// <summary>
        /// The <see cref="ILogger"/>.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreBoot"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws the <see cref="IServiceContainer"/> is not instantiated
        /// </exception>
        public CoreBoot(IServiceContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            _logger = Logger.CreateWithDefaultLog4NetConfiguration();

            // Self register the container
            container.Register<IServiceContainer>(_ => container);
            container.RegisterSingleton<ILogger>(function => _logger);
                

            _container = container;
        }

        /// <summary>
        /// Occurs after boot has been completed.
        /// </summary>
        public static event EventHandler Complete;

        /// <summary>
        /// Called on application start up
        /// </summary>
        public virtual void Boot()
        {
            _logger.Info<CoreBoot>("Catalyst People Problem Boot started");

            this.Compose(_container);

            // Stach the container
            Active.Container = _container;

            if (Complete != null) Complete.Invoke(this, new EventArgs());

            _logger.Info<CoreBoot>("Catalyst People Problem Boot completed");

        }

        /// <summary>
        /// Composes container services.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        internal virtual void Compose(IServiceContainer container)
        {
            // Caching
            container.RegisterFrom<CacheComposition>();

            // Data and database
            container.RegisterFrom<DataComposition>();
        }
    }
}