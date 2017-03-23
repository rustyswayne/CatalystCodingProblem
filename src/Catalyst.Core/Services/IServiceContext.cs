namespace Catalyst.Core.Services
{
    /// <summary>
    /// Represents the Catalyst "People Problem" service context.
    /// </summary>
    public interface IServiceContext
    {
        /// <summary>
        /// Gets the <see cref="IPersonService"/>.
        /// </summary>
        IPersonService Person { get; }
    }
}