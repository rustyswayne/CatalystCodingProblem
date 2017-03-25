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
        /// The <see cref="IAddressService"/>.
        /// </summary>
        private readonly Lazy<IAddressService> _addressService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceContext"/> class.
        /// </summary>
        /// <param name="peopleService">
        /// The people service.
        /// </param>
        /// <param name="addressService">
        /// The address Service.
        /// </param>
        public ServiceContext(
            Lazy<IPersonService> peopleService,
            Lazy<IAddressService> addressService)
        {
            _peopleService = peopleService;
            _addressService = addressService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceContext"/> class.
        /// </summary>
        /// <param name="personService">
        /// The people service.
        /// </param>
        /// <param name="addressService">
        /// The address Service.
        /// </param>
        public ServiceContext(
            IPersonService personService = null,
            IAddressService addressService = null)
        {
            if (personService != null) _peopleService = new Lazy<IPersonService>(() => personService);
            if (addressService != null) _addressService = new Lazy<IAddressService>(() => addressService);
        }

        /// <summary>
        /// Gets the <see cref="IPersonService"/>.
        /// </summary>
        public IPersonService Person => _peopleService.Value;

        /// <summary>
        /// Gets the <see cref="IAddressService"/>.
        /// </summary>
        public IAddressService AddressService => _addressService.Value;
    }
}