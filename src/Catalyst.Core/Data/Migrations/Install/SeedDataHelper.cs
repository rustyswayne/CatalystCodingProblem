namespace Catalyst.Core.Data.Migrations.Install
{
    using System;
    using System.Collections.Generic;

    using Catalyst.Core.Models;
    using Catalyst.Core.Models.Domain;

    using Newtonsoft.Json;

    /// <summary>
    /// A utility class for seeding initial (install) data.
    /// </summary>
    internal static class SeedDataHelper
    {
        /// <summary>
        /// Gets the people install data.
        /// </summary>
        /// <returns>
        /// Collection of persons for install data.
        /// </returns>
        public static IEnumerable<Person> GetDefaultPeople()
        {
            var ed = new ExtendedDataCollection();
            var interests = new[] { "Family", "Travel", "Movies", "Skiing", "SCUBA Diving", "Food" };
            ed.SetValue("interests", JsonConvert.SerializeObject(interests));

            return new List<Person>
            {
                new Person
                {
                    FirstName = "Russell",
                    LastName = "Swayne",
                    ExtendedData = JsonConvert.SerializeObject(ed.AsEnumerable()),
                    Birthday = DateTime.Parse("1971-08-06"),
                    Slug = "russell-swayne",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,

                    Addresses = new List<Address>
                    {
                        new Address
                            {
                                Name = "Disney World",
                                Address1 = "Walt Disney World Resort",
                                Locality = "Orlando",
                                Region = "Florida",
                                PostalCode = "32830",
                                CountryCode = "US",
                                CreateDate = DateTime.UtcNow,
                                UpdateDate = DateTime.UtcNow
                            },
                        new Address
                            {
                                Name = "Colosseum",
                                Address1 = "Piazza del Colosseo",
                                Address2 = "1",
                                Locality = "Roma",
                                PostalCode = "00184",
                                CountryCode = "IT",
                                CreateDate = DateTime.UtcNow,
                                UpdateDate = DateTime.UtcNow
                            }
                    }
                }
            };
        }
    }
}