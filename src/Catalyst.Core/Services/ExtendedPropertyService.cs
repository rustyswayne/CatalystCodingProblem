﻿namespace Catalyst.Core.Services
{
    using System.Data.Entity;

    using Catalyst.Core.Caching;
    using Catalyst.Core.Data.Context;
    using Catalyst.Core.Logging;
    using Catalyst.Core.Models.Domain;

    using LightInject;

    /// <inheritdoc />
    internal partial class ExtendedPropertyService : CatalystDbContextServiceBase<ExtendedProperty>, IExtendedPropertyService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedPropertyService"/> class.
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
        public ExtendedPropertyService([Inject(Constants.Database.ConnectionStringName)]ICatalystDbContext context, ICacheManager cache, ILogger logger)
            : base(context, cache, logger)
        {
        }

        /// <inheritdoc />
        protected override DbSet<ExtendedProperty> Context => DbContext.ExtendedProperties;

        /// <inheritdoc />
        protected override string EntitySetName => "ExtendedProperties";
    }
}