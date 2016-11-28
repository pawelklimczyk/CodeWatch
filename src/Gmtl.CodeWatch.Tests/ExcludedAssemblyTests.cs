using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class ExcludedAssemblyTests
    {
        private FieldNamingFirstLetterWatcher sut;

        [SetUp]
        public void Setup()
        {
            sut = new FieldNamingFirstLetterWatcher();
        }

        [Test]
        public void FieldNamingWatcherLowerCaseCheck_providedAssemblyWithUpperCasePropertiesToBeSkipped_ShouldPass()
        {
            sut.Configure(Naming.LowerCase);
            sut.SkipAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void FieldNamingWatcherLowerCaseCheck_providedAssemblyWithUpperCasePropertiesToBeWatchedAndSkipped_ShoudlPass()
        {
            var assembly = typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly;
            sut.Configure(Naming.LowerCase);
            sut.WatchAssembly(assembly);
            sut.SkipAssembly(assembly);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void FieldNamingWatcherLowerCaseCheck_providedAssemblyWithUpperCasePropertiesToBeSkippedAndWatched_ShoudlFail()
        {
            var assembly = typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly;
            sut.Configure(Naming.LowerCase);
            sut.SkipAssembly(assembly);
            sut.WatchAssembly(assembly);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
        }
    }
}