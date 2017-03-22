namespace Catalyst.Core.DI.Compositions
{
    using Catalyst.Core.Caching;

    using global::Catalyst.Core.Logging;

    using LightInject;

    /// <summary>
    /// Adds logging related service mappings to the container
    /// </summary>
    public class CoreComposition : ICompositionRoot
    {
        /// <inheritdoc />
        public void Compose(IServiceRegistry container)
        {
            container.Register<ICacheProvider, RequestCacheProvider>();

            // This need to be overridden in .Web
            container.Register<IRuntimeCacheProvider, NullCacheProvider>();

            container.RegisterSingleton<ICacheManager, CacheManager>();
        }
    }
}