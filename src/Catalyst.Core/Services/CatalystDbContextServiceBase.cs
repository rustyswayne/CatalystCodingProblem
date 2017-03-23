namespace Catalyst.Core.Services
{
    using System;

    using Catalyst.Core.Caching;
    using Catalyst.Core.Data.Context;
    using Catalyst.Core.Logging;
    using Catalyst.Core.Models.Entity;

    /// <summary>
    /// Represents a service based on the <see cref="ICatalystDbContext"/>.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of <see cref="IEntity"/>
    /// </typeparam>
    internal abstract class CatalystDbContextServiceBase<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalystDbContextServiceBase{TEntity}"/> class. 
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="cache">
        /// The cache.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws on any argument null
        /// </exception>
        protected CatalystDbContextServiceBase(ICatalystDbContext context, ICacheManager cache, ILogger logger)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (cache == null) throw new ArgumentNullException(nameof(cache));
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            Db = context;
            CacheManager = cache;
            Logger = logger;
        }

        /// <summary>
        /// Gets the <see cref="CatalystDbContext"/>.
        /// </summary>
        protected ICatalystDbContext Db { get; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// Gets the cache manager.
        /// </summary>
        protected ICacheManager CacheManager { get; }

        /// <summary>
        /// The runtime cache.
        /// </summary>
        protected IRuntimeCacheProvider RuntimeCache => CacheManager.RuntimeCache;

        /// <summary>
        /// Gets an entity by it's id.
        /// </summary>
        /// <param name="id">
        /// The id of the entity.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public virtual TEntity Get(Guid id)
        {
            var cacheKey = GetCacheKey(id);
            var result = RuntimeCache.GetCacheItem(cacheKey);

            if (result != null) return (TEntity)result;

            return (TEntity)RuntimeCache.GetCacheItem(cacheKey, () => PerformGet(id));
        }

        /// <summary>
        /// Performs the actual work of getting the entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        protected abstract TEntity PerformGet(Guid id);

        /// <summary>
        /// Gets the service cache key for the entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        protected string GetCacheKey(Guid id)
        {
            return $"{typeof(TEntity).Name}.{id}";
        }
    }
}