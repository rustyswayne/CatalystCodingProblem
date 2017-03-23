﻿namespace Catalyst.Core.Data.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Catalyst.Core.Models.Dto;

    /// <summary>
    /// Represents the database mapping for the <see cref="PersonDto"/>.
    /// </summary>
    internal class PersonDbMapping : EntityTypeConfiguration<PersonDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonDbMapping"/> class.
        /// </summary>
        public PersonDbMapping()
        {
            this.ToTable("catalystPerson");

            HasKey(x => x.Id);
            Property(x => x.Id).IsRequired();

            Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            Property(x => x.LastName).IsRequired().HasMaxLength(50);
            Property(x => x.Birthday).IsRequired();
            Property(x => x.ExtendedData).IsOptional();
            Property(x => x.Photo).IsOptional();

            HasMany(x => x.Addresses)
                .WithRequired(x => x.PersonDto)
                .Map(x => x.MapKey("PersonId"))
                .WillCascadeOnDelete(true);

            Property(x => x.UpdateDate).IsRequired();
            Property(x => x.CreateDate).IsRequired();
        }
    }
}