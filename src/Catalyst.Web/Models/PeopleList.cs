namespace Catalyst.Web.Models
{
    using System.Collections.Generic;

    using Catalyst.Core.Models.Domain;
    using Catalyst.Web.Models.Shared;

    /// <summary>
    /// Represents the people list page view model.
    /// </summary>
    public class PeopleList : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleList"/> class.
        /// </summary>
        public PeopleList()
        {
            Meta = new Meta
            {
                PageTitle = "People List - People Problem",
                Description = "Displays a list of all people that have been saved to the database"
            };
        }

        /// <summary>
        /// Gets or sets the people.
        /// </summary>
        public IEnumerable<Person> People { get; set; }
    }
}