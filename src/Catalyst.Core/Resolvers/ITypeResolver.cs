namespace Catalyst.Core.Resolvers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a simple type resolver.
    /// </summary>
    internal interface ITypeResolver
    {
        /// <summary>
        /// Returns a list of resolved types.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{Type}"/>.
        /// </returns>
        IEnumerable<Type> ResolveTypes();
    }
}