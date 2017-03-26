namespace Catalyst.Core.Controllers
{
    using System.Linq;

    using Catalyst.Core.DI;
    using Catalyst.Core.Models.PropData;
    using Catalyst.Core.ValueConverters;

    /// <summary>
    /// The property editor controller base.
    /// </summary>
    /// <typeparam name="TValue">
    /// The type of the value
    /// </typeparam>
    public abstract class PropertyEditorControllerBase<TValue> : CatalystControllerBase
        where TValue : class, IPropertyValueModel, new()
    {
        /// <summary>
        /// Gets the <see cref="IConverterMappingInfo"/>.
        /// </summary>
        public IConverterMappingInfo ConverterMapping => Active.ConverterMappings.FirstOrDefault(x => x.ValueType == typeof(TValue));
    }
}