using NUnit.Framework;

namespace Gmtl.CodeWatch.SampleProject.Tests
{
    public class GlobalContextTests
    {
        [Test]
        public void FluentConfigurationBuilder()
        {
            CodeWatcherConfig config = CodeWatcherConfig.Create()
                .WithWatcher(c => new FieldNamingWatcher(c).Configure(Naming.UpperCase))
                .WatchAssembly(typeof(DomainModel).Assembly)
                .Build();

            //This will throw exception
            config.Execute();
        }
    }
}