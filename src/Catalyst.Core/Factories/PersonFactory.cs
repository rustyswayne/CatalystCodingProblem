namespace Catalyst.Core.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Catalyst.Core.Models;
    using Catalyst.Core.Models.Dto;

    using Newtonsoft.Json;

    /// <summary>
    /// Responsible for person models.
    /// </summary>
    internal class PersonFactory : EntityFactoryBase<PersonDto, IPerson>
    {
        /// <summary>
        /// The <see cref="AddressFactory"/>.
        /// </summary>
        private readonly AddressFactory addressFactory = new AddressFactory();

        /// <inheritdoc />
        protected override PersonDto PerformBuildDTo(IPerson entity)
        {
           
            var dto = new PersonDto
                          {
                              FirstName = entity.FirstName,
                              LastName = entity.LastName,
                              Birthday = entity.Birthday,
                              Photo = entity.Photo,
                              ExtendedData = entity.ExtendedData.Serialize(),
                              Addresses = new Collection<AddressDto>(),
                              Slug = entity.Slug,
                              CreateDate = entity.CreateDate,
                              UpdateDate = entity.UpdateDate
                          };

            if (!entity.Id.Equals(Guid.Empty)) dto.Id = entity.Id;

            if (entity.Addresses.Any())
            {
                foreach (var adr in entity.Addresses)
                {
                    dto.Addresses.Add(addressFactory.BuildDto((Address)adr));
                }
            }

            return dto;
        }

        /// <inheritdoc />
        protected override IPerson PerformBuildEntity(PersonDto dto)
        {

            var ed = dto.ExtendedData.IsNullOrWhiteSpace() ?
                new ExtendedDataCollection() :
                new ExtendedDataCollection(
                    JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<string, string>>>(dto.ExtendedData));

            var entity = new Person
                             {
                                 Id = dto.Id,
                                 FirstName = dto.FirstName,
                                 LastName = dto.LastName,
                                 Birthday = dto.Birthday,
                                 Photo = dto.Photo,
                                 ExtendedData = ed,
                                 Slug = dto.Slug,
                                 Addresses = new List<IAddress>(),
                                 CreateDate = dto.CreateDate,
                                 UpdateDate = dto.UpdateDate
                             };

            if (dto.Addresses.Any())
            {
                foreach (var adr in dto.Addresses)
                {
                    entity.Addresses.Add(addressFactory.BuildEntity(adr));
                }
            }

            return entity;
        }
    }
}