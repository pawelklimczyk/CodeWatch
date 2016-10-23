using NUnit.Framework;

namespace Gmtl.CodeWatch.SampleProject.Tests
{
    [TestFixture]
    public class WatchPropertyNamesInAssemblies
    {
        [Test]
        public void AllPropertiesInAssemblyMustStartWithUppercase()
        {
            PropertyNamingWatcher propertyNamingWatcher = new PropertyNamingWatcher();
            propertyNamingWatcher.Configure(Naming.UpperCase);
            propertyNamingWatcher.WatchAssembly(typeof(DomainModel).Assembly);

            //This will throw exception
            propertyNamingWatcher.Execute();
        }
    }
}