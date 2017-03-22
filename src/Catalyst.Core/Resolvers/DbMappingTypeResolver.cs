namespace Catalyst.Core.Resolvers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The DB mapping type resolver.
    /// </summary>
    internal class DbMappingTypeResolver : ITypeResolver
    {
        private static ITypeResolver _instance;
        
        private DbMappingTypeResolver()
        {
        }

        public static ITypeResolver Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DbMappingTypeResolver();
                }

                return _instance;
            }
        }

        public IEnumerable<Type> ResolveTypes()
        {
            throw new NotImplementedException();
        }
    }
}