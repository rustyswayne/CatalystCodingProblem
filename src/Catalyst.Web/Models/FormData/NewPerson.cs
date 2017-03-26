namespace Catalyst.Web.Models.FormData
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents form date for a new person entry.
    /// </summary>
    public class NewPerson
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Display(Name = "First name"), Required(ErrorMessage = " * required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Display(Name = "Last name"), Required(ErrorMessage = " * required")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birthday.
        /// </summary>
        [Display(Name = "Birthday"), Required(ErrorMessage = " * required")]
        public DateTime Birthday { get; set; }
    }
}