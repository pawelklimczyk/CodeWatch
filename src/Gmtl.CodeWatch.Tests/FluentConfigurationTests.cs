using System.Linq;
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
                .WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.UpperCase))
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            Assert.IsTrue(watcherConfig.Execute().HasIssues);
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_providedAssemblyWithUppercasePropertiesShouldFail()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.LowerCase))
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            Assert.IsFalse(watcherConfig.Execute().HasIssues);
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_providedAssemblyWithUppercasePropertiesAndSkippingItShouldPass()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.LowerCase))
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .SkipAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            Assert.IsTrue(watcherConfig.Execute().HasIssues);
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_skippingAssemblyWithUppercasePropertiesAndAddingItShouldFail()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.LowerCase))
                .SkipAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            Assert.IsFalse(watcherConfig.Execute().HasIssues);
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_providedTypeWithUppercasePropertiesShouldFail()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.LowerCase))
                .WatchType(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1))
                .Build();

            Assert.IsFalse(watcherConfig.Execute().HasIssues);
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_providedTypeWithUppercasePropertiesAndSkippingItShouldPass()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.LowerCase))
                .WatchType(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1))
                .SkipType(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1))
                .Build();

            Assert.IsTrue(watcherConfig.Execute().HasIssues);
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_skippingTypeWithUppercasePropertiesAndWatchingitBackShouldFail()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.LowerCase))
                .SkipType(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1))
                .WatchType(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1))
                .Build();

            Assert.IsFalse(watcherConfig.Execute().HasIssues);
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_skippingAssemblyWithUppercasePropertiesAndWatchingUppercaseTypeFromThatAssemblyShouldFail()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.LowerCase))
                .SkipAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .WatchType(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1))
                .Build();

            Assert.IsFalse(watcherConfig.Execute().HasIssues);
        }

        [Test]
        public void FluentConfigurationBuilderWithLowercasePropertyWatcher_watchingAssemblyWithUppercasePropertiesAndSkippingUppercaseTypeFromThatAssemblyShouldFailWithoutThatType()
        {
            CodeWatcherConfig watcherConfig = CodeWatcherConfig.Create()
                .WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.LowerCase))
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .SkipType(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1))
                .Build();

            var result = watcherConfig.Execute();

            Assert.IsFalse(result.HasIssues);
            Assert.That(result.Issues.All(e => !e.Message.Contains("Class1")));
        }
    }
}