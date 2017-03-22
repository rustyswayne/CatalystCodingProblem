﻿namespace Catalyst.Tests.Boot
{
    using Catalyst.Core.DI;
    using Catalyst.Tests.TestHelpers;

    using NUnit.Framework;

    /// <summary>
    /// Tests the "Active" static class
    /// </summary>
    public class ActiveTests : CoreBootTestBase
    {
        [Test]
        public void Logger()
        {
            //// Arrange - handled in base
            
            //// Act - handled in base
            
            //// Assert
            Assert.That(Active.Logger, Is.Not.Null);
        }
    }
}