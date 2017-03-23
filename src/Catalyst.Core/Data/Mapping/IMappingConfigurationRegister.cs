﻿namespace Catalyst.Core.Data.Mapping
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a register of Model Type Mapping Configurations.
    /// </summary>
    public interface IMappingConfigurationRegister
    {
        /// <summary>
        /// Gets the resolved instance types.
        /// </summary>
        IEnumerable<Type> InstanceTypes { get; }

        /// <summary>
        /// Returns instantiations of resolved instance types.
        /// </summary>
        /// <returns>
        /// The collection of instantiated configuration types .
        /// </returns>
        IEnumerable<dynamic> GetInstantiations();
    }
}