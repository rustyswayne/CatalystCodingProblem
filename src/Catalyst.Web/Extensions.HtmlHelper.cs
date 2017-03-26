namespace Catalyst.Web
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    using Catalyst.Core;

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
            return html.If(condition(), value, otherwise);
        }

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
        public static IHtmlString If(this HtmlHelper html, bool condition, string value, string otherwise = "")
        {
            return condition
               ? MvcHtmlString.Create(value)
               : otherwise.IsNullOrWhiteSpace() ? MvcHtmlString.Empty : MvcHtmlString.Create(otherwise);
        }

        /// <summary>
        /// Gets a thumbnail.
        /// </summary>
        /// <param name="html">
        /// The <see cref="HtmlHelper"/>.
        /// </param>
        /// <param name="src">
        /// The image source.
        /// </param>
        /// <param name="fallbackSrc">
        /// The fallback image source.
        /// </param>
        /// <param name="alt">
        /// The alternative text.
        /// </param>
        /// <param name="cssclass">
        /// The CSS class.
        /// </param>
        /// <param name="queryString">
        /// The query string.
        /// </param>
        /// <returns>
        /// The <see cref="IHtmlString"/>.
        /// </returns>
        public static IHtmlString Thumbnail(this HtmlHelper html, string src, string fallbackSrc = "", string alt = "", string cssclass = "", string queryString = "")
        {
            if (src.IsNullOrWhiteSpace() && fallbackSrc.IsNullOrWhiteSpace()) return MvcHtmlString.Empty;

            if (!queryString.IsNullOrWhiteSpace()) queryString = queryString.EnsureStartsWith('?');

            var imgSrc = !src.IsNullOrWhiteSpace() ? src : fallbackSrc;

            var css = $"class=\"{cssclass}\"".Trim();

            return MvcHtmlString.Create($"<img src=\"{imgSrc}{queryString}\" alt=\"{HttpUtility.HtmlEncode(alt)}\" {css} />");
        }
    }
}