namespace Catalyst.Core.DI
{
    using System;

    using Catalyst.Core.Caching;

    using global::Catalyst.Core.Logging;

    using LightInject;

    /// <summary>
    /// Exposes Catalyst the container.
    /// </summary>
    public static class Active
    {
        /// <summary>
        /// The <see cref="IServiceContainer"/>.
        /// </summary>
        private static IServiceContainer _container;

        /// <summary>
        /// The <see cref="ILogger"/>.
        /// </summary>
        public static ILogger Logger => Container.GetInstance<ILogger>();

        /// <summary>
        /// The <see cref="CacheManager"/>.
        /// </summary>
        public static ICacheManager CacheManager => Container.GetInstance<ICacheManager>();

        /// <summary>
        /// Gets or sets the <see cref="IServiceContainer"/>.
        /// </summary>
        /// <exception cref="NullReferenceException">
        /// Throws an exception if the singleton has not been instantiated.
        /// </exception>
        internal static IServiceContainer Container
        {
            get
            {
                if (_container == null) throw new NullReferenceException("Container has not been set");
                return _container;
            }

            set
            {
                _container = value;
            }
        }
    }
}