namespace Catalyst.Core.DI.Compositions
{
    using Catalyst.Core.Data.Context;
    using Catalyst.Core.Data.Mapping;

    using LightInject;

    /// <summary>
    /// Adds data related service mappings to the container
    /// </summary>
    internal class DataComposition : ICompositionRoot
    {
        /// <inheritdoc />
        public void Compose(IServiceRegistry container)
        {

            container.RegisterSingleton<IMappingConfigurationRegister, DbMappingRegister>();

            // Transient
            container.Register<ICatalystDbContext, CatalystDbContext>();
        }
    }
}