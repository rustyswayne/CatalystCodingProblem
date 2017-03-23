namespace Catalyst.Tests.TestHelpers
{
    using Catalyst.Core.Boot;
    using Catalyst.Core.DI;

    using LightInject;

    using NUnit.Framework;

    [TestFixture]
    public abstract class CoreBootTestBase
    {
        [OneTimeSetUp]
        public virtual void Initialize()
        {
            var container = new ServiceContainer();
            container.EnableAnnotatedConstructorInjection();
            container.EnableAnnotatedPropertyInjection();

            var loader = new CoreBoot(container);

            loader.Boot();
        }

        [OneTimeTearDown]
        public virtual void Teardown()
        {
            if (Active.Container != null) Active.Container.Dispose();
        }
    }
}