namespace Catalyst.Core.Models.Domain
{
    using System;
    using System.Collections.Generic;

    using Catalyst.Core.Data;

    /// <summary>
    /// Represents a person DTO.
    /// </summary>
    public class Person : IPerson, IDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            this.Id = GuidComb.GenerateComb();
        }

        /// <inheritdoc />
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <inheritdoc />
        public string ExtendedData { get; set; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; }

        /// <inheritdoc />
        public DateTime UpdateDate { get; set; }

        /// <inheritdoc />
        public DateTime CreateDate { get; set; }
    }
}