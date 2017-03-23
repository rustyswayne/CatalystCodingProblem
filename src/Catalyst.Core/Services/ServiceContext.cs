namespace Catalyst.Core.Services
{
    using System;

    /// <inheritdoc />
    internal class ServiceContext : IServiceContext
    {
        /// <summary>
        /// The <see cref="IPersonService"/>.
        /// </summary>
        private readonly Lazy<IPersonService> _peopleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceContext"/> class.
        /// </summary>
        /// <param name="peopleService">
        /// The people service.
        /// </param>
        public ServiceContext(
            Lazy<IPersonService> peopleService)
        {
            _peopleService = peopleService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceContext"/> class.
        /// </summary>
        /// <param name="personService">
        /// The people service.
        /// </param>
        public ServiceContext(IPersonService personService = null)
        {
            if (personService != null) _peopleService = new Lazy<IPersonService>(() => personService);
        }

        /// <summary>
        /// Gets the <see cref="IPersonService"/>.
        /// </summary>
        public IPersonService Person => _peopleService.Value;
    }
}