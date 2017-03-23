﻿namespace Catalyst.Core.Data.Initializers
{
    using System.Data.Entity;

    using Catalyst.Core.Data.Context;

    /// <summary>
    /// The default CatalystDb initializer.
    /// Drops the database if any of the domain models have changed.
    /// </summary>
    // ReSharper disable once StyleCop.SA1650
    public class DefaultCatalystDbInitializer : DropCreateDatabaseIfModelChanges<CatalystDbContext>
    {
        /// <inheritdoc />
        protected override void Seed(CatalystDbContext context)
        {
            base.Seed(context);

            foreach (var person in SeedDataHelper.GetDefaultPeople())
            {
                context.People.Add(person);
            }
            context.SaveChanges();
        }
    }
}