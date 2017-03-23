namespace Catalyst.Core.Factories
{
    using System;

    using Catalyst.Core.Models;
    using Catalyst.Core.Models.Dto;

    /// <summary>
    /// Responsible for address models
    /// </summary>
    internal class AddressFactory : IEntityFactory<AddressDto, Address>
    {
        /// <inheritdoc />
        public AddressDto BuildDto(Address entity)
        {
            var dto = new AddressDto
                       {
                            Name = entity.Name,
                            Address1 = entity.Address1,
                            Address2 = entity.Address2,
                            Locality = entity.Locality,
                            Region = entity.Region,
                            PostalCode = entity.PostalCode,
                            CountryCode = entity.CountryCode,
                            CreateDate = entity.CreateDate,
                            UpdateDate = entity.UpdateDate
                       };

            if (!entity.Id.Equals(Guid.Empty)) dto.Id = entity.Id;

            return dto;
        }

        /// <inheritdoc />
        public Address BuildEntity(AddressDto dto)
        {
            return new Address
                       {
                           Id = dto.Id,
                           Name = dto.Name,
                           Address1 = dto.Address1,
                           Address2 = dto.Address2,
                           Locality = dto.Locality,
                           Region = dto.Region,
                           PostalCode = dto.PostalCode,
                           CountryCode = dto.CountryCode,
                           CreateDate = dto.CreateDate,
                           UpdateDate = dto.UpdateDate
                       };
        }
    }
}