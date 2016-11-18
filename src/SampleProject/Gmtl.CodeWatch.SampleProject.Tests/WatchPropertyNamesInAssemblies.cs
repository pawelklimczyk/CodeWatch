using Gmtl.CodeWatch.Watchers;
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

            propertyNamingWatcher.Execute();

            //ruleViolations contain all properties that are not uppercase
            var ruleViolations = propertyNamingWatcher.Issues;

            //Failure!
            Assert.That(ruleViolations.Count, Is.EqualTo(0));
        }
    }
}