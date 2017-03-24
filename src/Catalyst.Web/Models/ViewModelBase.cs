﻿namespace Catalyst.Web.Models
{
    using Catalyst.Web.Models.Shared;

    /// <summary>
    /// Represents a base view model.
    /// </summary>
    public abstract class ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        protected ViewModelBase()
        {
            this.Meta = new Meta();
        }

        /// <summary>
        /// Gets or sets the page <see cref="Meta"/>.
        /// </summary>
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets the current url.
        /// </summary>
        public NavTab CurrentTab { get; set; }
    }
}