namespace Catalyst.Web
{
    using Catalyst.Core;

    using System;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Extension methods for the <see cref="HtmlHelper"/>.
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Utility inline if.
        /// </summary>
        /// <param name="html">
        /// The <see cref="HtmlHelper"/>.
        /// </param>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="otherwise">
        /// The otherwise (else) value.
        /// </param>
        /// <returns>
        /// The <see cref="IHtmlString"/>.
        /// </returns>
        public static IHtmlString If(this HtmlHelper html, Func<bool> condition, string value, string otherwise = "")
        {
            return condition()
                       ? MvcHtmlString.Create(value)
                       : otherwise.IsNullOrWhiteSpace() ? MvcHtmlString.Empty : MvcHtmlString.Create(otherwise);
        }
    }
}