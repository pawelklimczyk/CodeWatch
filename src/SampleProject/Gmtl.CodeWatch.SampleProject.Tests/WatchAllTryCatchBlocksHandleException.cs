using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.SampleProject.Tests
{
    [TestFixture]
    public class WatchAllTryCatchBlocksHandleException
    {
        [Test]
        public void AllTryCatchBlocksInAssembyMustBeHandedl()
        {
            ExceptionHandlingWatcher exceptionHandlingWatcher = new ExceptionHandlingWatcher();
            exceptionHandlingWatcher.WatchAssembly(typeof(DomainModel).Assembly);

            exceptionHandlingWatcher.Execute();

            //ruleViolations contain all methods that not handle exceptions properly
            var ruleViolations = exceptionHandlingWatcher.Issues;

            //Failure!
            Assert.That(ruleViolations.Count, Is.EqualTo(0));
        }
    }
}