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
    using Catalyst.Core.Models.Dto;
    using Catalyst.Core.Models.Entity;

    /// <summary>
    /// Represents a service based on the <see cref="ICatalystDbContext"/>.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of <see cref="IEntity"/>
    /// </typeparam>
    /// <typeparam name="TDto">
    /// The type of the <see cref="IDto"/>
    /// </typeparam>
    internal abstract class CatalystDbContextServiceBase<TEntity, TDto> : ISimpleDbContextCrudService<TEntity>
        where TEntity : IEntity
        where TDto : class, IDto, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalystDbContextServiceBase{TEntity,TDto}"/> class. 
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

            DbContext = (CatalystDbContext)context;
            CacheManager = cache;
            Logger = logger;
        }

        /// <summary>
        /// Gets or sets the <see cref="DbContext"/>.
        /// </summary>
        protected CatalystDbContext DbContext { get; set; }

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
        /// Gets the <see cref="CatalystDbContext"/>.
        /// </summary>
        protected abstract DbSet<TDto> Db { get; }

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

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> GetAll(params Guid[] ids)
        {
            if (!ids.Any())
            {
                return Db.ToArray().Select(x => Get(x.Id)).Where(x => x != null);
            }

            return ids.Select(this.Get).Where(x => x != null);
        }

        /// <inheritdoc />
        public virtual void Save(TEntity entity)
        {
            if (entity.HasIdentity())
            {
                PerformUpdate(entity);
            }
            else
            {
                PerformAdd(entity);
            }
        }

        /// <inheritdoc />
        public virtual void Delete(TEntity entity)
        {
            var dto = Db.Find(entity.Id);
            if (dto != null)
            {
                Db.Remove(dto);
                DbContext.SaveChanges();
            }
        }

        /// <inheritdoc />
        public virtual int Count()
        {
            return Db.Count();
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
        protected virtual TEntity PerformGet(Guid id)
        {
            var dto = Db.Find(id);
            if (dto == null) return default(TEntity);

            var factory = GetFactory();
            return factory.BuildEntity(dto);
        }

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

        /// <summary>
        /// Gets the factory to convert the models.
        /// </summary>
        /// <returns>
        /// The <see cref="EntityFactoryBase{TDto, TEntity}"/>.
        /// </returns>
        protected abstract EntityFactoryBase<TDto, TEntity> GetFactory();

        /// <summary>
        /// Performs the work of adding an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected virtual void PerformAdd(TEntity entity)
        {
            var factory = GetFactory();
            entity.UpdatingEntity();
            var dto = factory.BuildDto(entity);
            Db.Add(dto);
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Performs the work of updating an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        protected virtual void PerformUpdate(TEntity entity)
        {
            var factory = GetFactory();
            entity.AddingEntity();
            var dto = factory.BuildDto(entity);
            Db.Attach(dto);
            DbContext.SaveChanges();
        }
    }
}