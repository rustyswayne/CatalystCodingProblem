﻿namespace Catalyst.Web.Models.Boxes
{
    using System.Collections.Generic;

    using Catalyst.Core.Models.Domain;

    /// <summary>
    /// The recently added box.
    /// </summary>
    public class RecentlyAddedBox : BoxBase
    {
        /// <inheritdoc />
        public override string Title => "Recently Added";

        /// <summary>
        /// Gets or sets the recently updated.
        /// </summary>
        public IEnumerable<Person> RecentlyUpdated { get; set; }

        /// <summary>
        /// Gets or sets the number of total people.
        /// </summary>
        public long TotalPeople { get; set; }
    }
}