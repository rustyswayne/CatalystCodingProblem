namespace Catalyst.Web.Models
{
    using System.Collections.Generic;

    using Catalyst.Core.Models.Domain;

    /// <summary>
    /// Represents the people list page view model.
    /// </summary>
    public class PeopleList : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the people.
        /// </summary>
        public IEnumerable<Person> People { get; set; }
    }
}