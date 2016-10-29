using Gmtl.CodeWatch.Watchers;
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
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_providedAssemblyWithUppercasePropertiesShouldFail()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingWatcher(c).Configure(Naming.LowerCase))
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            Assert.Throws<CodeWatchAggregatedException>(() => watcherConfig.Execute());
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_providedAssemblyWithUppercasePropertiesAndSkippingItShouldPass()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingWatcher(c).Configure(Naming.LowerCase))
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .SkipAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            watcherConfig.Execute();
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_skippingAssemblyWithUppercasePropertiesAndAddingItShouldFail()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingWatcher(c).Configure(Naming.LowerCase))
                .SkipAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            Assert.Throws<CodeWatchAggregatedException>(() => watcherConfig.Execute());
        }
    }
}