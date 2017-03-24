namespace Catalyst.Core.DI.Compositions
{
    using Catalyst.Core.Data.Context;
    using Catalyst.Core.Data.Mapping;
    using Catalyst.Core.Logging;
    using Catalyst.Core.Registers;

    using LightInject;

    /// <summary>
    /// Adds data related service mappings to the container
    /// </summary>
    internal class DataComposition : ICompositionRoot
    {
        /// <inheritdoc />
        public void Compose(IServiceRegistry container)
        {
            // Transient
            container.Register<ICatalystDbContext, CatalystDbContext>();

            container.Register<string, ICatalystDbContext>(
                (factory, connStr) => new CatalystDbContext(
                    connStr,
                    factory.GetInstance<ILogger>(),
                    factory.GetInstance<IMappingConfigurationRegister>()));

            container.Register<ICatalystDbContext>(
                factory =>
                    new CatalystDbContext(
                        Constants.Database.ConnectionStringName,
                        factory.GetInstance<ILogger>(),
                        factory.GetInstance<IMappingConfigurationRegister>()),
                Constants.Database.ConnectionStringName);
        }
    }
}