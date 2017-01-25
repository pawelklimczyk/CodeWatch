using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.SampleProject.Tests
{
    public class GlobalContextTests
    {
        [Test]
        public void FluentConfigurationBuilder()
        {
            CodeWatcherConfig config = CodeWatcherConfig.Create()
                .WithWatcher(c => new FieldNamingFirstLetterWatcher(c).Configure(Naming.UpperCase))
                .WatchAssembly(typeof(DomainModel).Assembly)
                .Build();

            //execute configuration
            var result = config.Execute();

            //This will throw exception
            Assert.True(result.HasIssues);
        }
    }
}