using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.SampleProject.Tests
{
    [TestFixture]
    public class WatchPropertyNamesInAssemblies
    {
        [Test]
        public void AllPropertiesInAssemblyMustStartWithUppercaseWillFail()
        {
            PropertyNamingFirstLetterWatcher propertyNamingWatcher = new PropertyNamingFirstLetterWatcher();
            propertyNamingWatcher.Configure(Naming.UpperCase);
            propertyNamingWatcher.WatchAssembly(typeof(DomainModel).Assembly);

            propertyNamingWatcher.Execute();

            //ruleViolations contain all properties that are not uppercase
            var ruleViolations = propertyNamingWatcher.Issues;

            //Failure!
            Assert.That(ruleViolations.Count, Is.GreaterThan(0));
        }
    }
}