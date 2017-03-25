namespace Catalyst.Web.Models.Dashboard
{
    using System.Collections.Generic;

    /// <summary>
    /// Model for dashboard item that lists countries associated with people tracked.
    /// </summary>
    public class CountriesSnapshot : DashboardItemBase
    {
        /// <inheritdoc />                                     
        public override string Title => "Top Countries";

        /// <summary>
        /// Gets or sets the country metrics.
        /// </summary>
        public IEnumerable<CountryMetric> Metrics { get; set; }
    }

    /// <summary>
    /// Represents a Country Metric.
    /// </summary>
    // ReSharper disable once StyleCop.SA1402
    public class CountryMetric
    {
        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the english country name.
        /// </summary>
        public string EnglishCountryName { get; set; }

        /// <summary>
        /// Gets or sets the people count.
        /// </summary>
        public int PeopleCount { get; set; }
    }
}