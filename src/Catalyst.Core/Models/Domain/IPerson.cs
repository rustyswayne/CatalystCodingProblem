﻿namespace Catalyst.Core.Models.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a Person.
    /// </summary>
    public interface IPerson : IEntity, IExtendedData
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
        /// Gets or sets the photo.
        /// </summary>
        string Photo { get; set; }

        /// <summary>
        /// Gets the addresses.
        /// </summary>
        ICollection<Address> Addresses { get; }
    }
}