namespace Catalyst.Core.Models.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Catalyst.Core.Data;

    /// <summary>
    /// Represents an street or postal address.
    /// </summary>
    [Table("catAddress")]
    internal sealed class Address : IAddress, IDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
            Id = GuidComb.GenerateComb();
        }

        /// <inheritdoc />
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the person id.
        /// </summary>
        /// <remarks>
        /// Foreign key
        /// </remarks>
        public Guid PersonId { get; set; }

        /// <inheritdoc />
        [MaxLength(255)]
        public string Name { get; set; }

        /// <inheritdoc />
        [MaxLength(500)]
        public string Address1 { get; set; }

        /// <inheritdoc />
        [MaxLength(500)]
        public string Address2 { get; set; }

        /// <inheritdoc />
        [MaxLength(255)]
        public string Locality { get; set; }

        /// <inheritdoc />
        [MaxLength(255)]
        public string Region { get; set; }

        /// <inheritdoc />
        [MaxLength(50)]
        public string PostalCode { get; set; }

        /// <inheritdoc />
        [MaxLength(3)]
        public string CountryCode { get; set; }

        /// <inheritdoc />
        public DateTime UpdateDate { get; set; }

        /// <inheritdoc />
        public DateTime CreateDate { get; set; }
    }
}