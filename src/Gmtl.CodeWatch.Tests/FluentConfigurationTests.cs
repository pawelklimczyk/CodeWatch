using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class FluentConfigurationTests
    {
        [Test]
        public void FluentConfigurationBuilderWithUppercasePropertyWatcher_providedAssemblyWithUppercasePropertiesShouldPass()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingWatcher(c).Configure(Naming.UpperCase))
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            watcherConfig.Execute();
        }

        [Test]
        public void FluentConfigurationBuilderWithUppercasePropertyWatcher_providedAssemblyWithLowercasePropertiesShouldFail()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingWatcher(c).Configure(Naming.LowerCase))
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            Assert.Throws<CodeWatchException>(() => watcherConfig.Execute());
        }
    }
}