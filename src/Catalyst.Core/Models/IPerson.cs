namespace Catalyst.Core.Models
{
    using System;
    using System.Collections.Generic;

    using Catalyst.Core.Models.Entity;

    /// <summary>
    /// Represents a Person.
    /// </summary>
    public interface IPerson : IEntity
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets the slug.
        /// </summary>
        string Slug { get; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        DateTime Birthday { get; set; }

        /// <summary>
        /// Gets the <see cref="ExtendedDataCollection"/>.
        /// </summary>
        ExtendedDataCollection ExtendedData { get; }

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        string Photo { get; set; }

        /// <summary>
        /// Gets the addresses.
        /// </summary>
        IList<IAddress> Addresses { get; }
    }
}