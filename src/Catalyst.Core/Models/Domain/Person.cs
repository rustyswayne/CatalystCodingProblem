namespace Catalyst.Core.Models.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Catalyst.Core.Data;

    /// <summary>
    /// Represents a person DTO.
    /// </summary>
    [Table("catPerson")]
    internal sealed class Person : IDto, IExtendedData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            Id = GuidComb.GenerateComb();
        }

        /// <inheritdoc />
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <inheritdoc />
        public string ExtendedData { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        [MaxLength(500)]
        public string Photo { get; set; }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        public List<Address> Addresses { get; set; }

        /// <inheritdoc />
        public DateTime UpdateDate { get; set; }

        /// <inheritdoc />
        public DateTime CreateDate { get; set; }
    }
}