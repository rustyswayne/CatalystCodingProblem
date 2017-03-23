namespace Catalyst.Core.Data.Context
{
    using System.Data.Entity;

    using Catalyst.Core.Models.Dto;

    /// <summary>
    /// Represents the Catalyst <see cref="DbContext"/>.
    /// </summary>
    internal interface ICatalystDbContext
    {
        /// <summary>
        /// Gets or sets the people <see cref="DbSet"/>.
        /// </summary>
        DbSet<AddressDto> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the addresses <see cref="DbSet"/>.
        /// </summary>
        DbSet<PersonDto> People { get; set; }
    }
}