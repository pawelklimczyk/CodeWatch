using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.SampleProject.Tests
{
    [TestFixture]
    public class WatchFieldNamesInAssemblies
    {
        [Test]
        public void AllPropertiesInAssemblyMustStartWithUppercaseWillFail()
        {
            FieldNamingFirstLetterWatcher fieldNamingWatcher = new FieldNamingFirstLetterWatcher();
            fieldNamingWatcher.Configure(Naming.UpperCase);
            fieldNamingWatcher.WatchAssembly(typeof(DomainModel).Assembly);

            fieldNamingWatcher.Execute();

            //ruleViolations contain all fields that are not uppercase
            var ruleViolations = fieldNamingWatcher.Issues;

            //Failure!
            Assert.That(ruleViolations.Count,Is.GreaterThan(0));
        }
    }
}