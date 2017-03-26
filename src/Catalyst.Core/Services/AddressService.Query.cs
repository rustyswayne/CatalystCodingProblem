namespace Catalyst.Core.Services
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Catalyst.Core.Models;

    /// <inheritdoc />
    internal partial class AddressService : IAddressQueryService
    {
        /// <inheritdoc />
        public IEnumerable<ICountry> GetAssociatedCountries(int count = int.MaxValue)
        {
            var codes = Context
                        .AsNoTracking()
                        .Select(x => x.CountryCode)
                        .Where(x => x.Length >= 2)
                        .Distinct()
                        .Take(count);

            return codes
                    .Select(GetCountry)
                    .ToArray()
                    .Where(x => x != null)
                    .OrderBy(x => x.Name);
        }

        /// <inheritdoc />
        public int CountPeopleAddressInCountry(string countryCode)
        {
            // TODO - review SQL
            return
                Context.AsNoTracking()
                    .Where(x => x.CountryCode.Equals(countryCode, System.StringComparison.CurrentCultureIgnoreCase))
                    .Select(x => x.Person)
                    .Distinct()
                    .Count();
        }

        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <returns>
        /// The <see cref="ICountry"/>.
        /// </returns>
        private ICountry GetCountry(string code)
        {
            return GetAllCountries().FirstOrDefault(x => x.Code.Equals(code, System.StringComparison.InvariantCultureIgnoreCase));
        }

        ///// <summary>
        ///// Gets a collection of countries.
        ///// </summary>
        ///// <param name="codes">
        ///// 2 digit country codes.
        ///// </param>
        ///// <returns>
        ///// The collection <see cref="IEnumerable{ICountry}"/>.
        ///// </returns>
        //private IEnumerable<ICountry> GetCountries(params string[] codes)
        //{
        //    if (!codes.Any()) return Enumerable.Empty<ICountry>();

        //    var distinctCodes = codes.Distinct();

        //    return GetAllCountries()
        //            .Where(country => distinctCodes.Contains(country.Code))
        //            .OrderBy(country => country.Name);
        //}

        /// <summary>
        /// Gets a collection of all  <see cref="ICountry"/>
        /// </summary>
        /// <returns>
        /// The collection of all countries.
        /// </returns>
        private IEnumerable<ICountry> GetAllCountries()
        {
            const string CacheKey = "ALLCOUNTRIES";

            return (IEnumerable<ICountry>)RuntimeCache.GetCacheItem(
                    CacheKey,
                    () =>
                    {
                        //// TODO - this needs to be refactored: 
                        ////    Possible to return multiple countries for a given 2 digit code
                        ////    Culture info does not account for every country.
                        return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                            .Select(culture => new RegionInfo(culture.Name))
                            .Select(ri => new Country { Code = ri.TwoLetterISORegionName, Name = ri.EnglishName })
                            .ToArray();
                    });

        }
    }
}
