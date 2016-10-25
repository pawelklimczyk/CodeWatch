using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.SampleProject.Tests
{
    [TestFixture]
    public class WatchFieldNamesInAssemblies
    {
        [Test]
        public void AllPropertiesInAssemblyMustStartWithUppercase()
        {
            FieldNamingWatcher fieldNamingWatcher = new FieldNamingWatcher();
            fieldNamingWatcher.Configure(Naming.UpperCase);
            fieldNamingWatcher.WatchAssembly(typeof(DomainModel).Assembly);

            fieldNamingWatcher.Execute();

            //ruleViolations contain all fields that are not uppercase
            var ruleViolations = fieldNamingWatcher.Issues;

            //Failure!
            Assert.That(ruleViolations.Count,Is.EqualTo(0));
        }
    }
}