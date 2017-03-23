namespace Catalyst.Core.Data.Initializers
{
    using System.Data.Entity;

    using Catalyst.Core.Data.Context;

    /// <summary>
    /// Overrides the default DropCreate initializer.
    /// </summary>
    /// <remarks>
    /// This will not seed any data!
    /// </remarks>
    public class DropAlwaysCatalystDbInitializer : DropCreateDatabaseAlways<CatalystDbContext>
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