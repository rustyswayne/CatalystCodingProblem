namespace Catalyst.Web.Models
{
    using Catalyst.Core.Models.Domain;

    /// <summary>
    /// Represents a person detail view model.
    /// </summary>
    public class PersonDetail : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        public Person Person { get; set; }
    }
}