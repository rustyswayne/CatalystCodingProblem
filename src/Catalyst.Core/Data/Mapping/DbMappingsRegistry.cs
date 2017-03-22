namespace Catalyst.Core.Data.Mapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A register for database mapping types.
    /// </summary>
    internal class DbMappingsRegister
    {
        /// <summary>
        /// The <see cref="Type"/>s registered.
        /// </summary>
        private readonly List<Type> _types = new List<Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DbMappingsRegister"/> class.
        /// </summary>
        /// <param name="mappingTypes">
        /// The mapping types.
        /// </param>
        public DbMappingsRegister(IEnumerable<Type> mappingTypes)
        {
            _types.AddRange(mappingTypes);
        }

        /// <summary>
        /// The instance types.
        /// </summary>
        public IEnumerable<Type> InstanceTypes => _types;
    }
}