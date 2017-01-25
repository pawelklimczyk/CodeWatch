using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.SampleProject.Tests
{
    public class GlobalContextTests
    {
        [Test]
        public void FluentConfigurationBuilderWillFailForFields()
        {
            CodeWatcherConfig config = CodeWatcherConfig.Create()
                .WithWatcher(c => new FieldNamingFirstLetterWatcher(c).Configure(Naming.UpperCase))
                .WatchAssembly(typeof(DomainModel).Assembly)
                .Build();

            //execute configuration
            var result = config.Execute();

            //This will fail
            Assert.True(result.HasIssues);
        }

        [Test]
        public void FluentConfigurationBuilderWillPassForFields()
        {
            CodeWatcherConfig config = CodeWatcherConfig.Create()
                .WithWatcher(c => new FieldNamingFirstLetterWatcher(c).Configure(Naming.Underscore))
                .WatchAssembly(typeof(DomainModel).Assembly)
                .Build();

            //execute configuration
            var result = config.Execute();

            //This will pass
            Assert.False(result.HasIssues);
        }
    }
}