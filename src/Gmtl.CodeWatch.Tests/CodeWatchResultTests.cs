using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class CodeWatchResultTests
    {
        [Test]
        public void CodeWatchAggregatedException_providedAssemblyWith5ViolatedProperties_shouldReturnAggregateExcWith5SubExceptions()
        {
            var result = AssertThatWatcherThrowException();

            Assert.That(result.Issues.Count, Is.EqualTo(5));
        }

        [Test]
        public void CodeWatchAggregatedException_ToStringShouldContainSubExceptionDetails()
        {
            var exception = AssertThatWatcherThrowException();

            StringAssert.Contains("Class1", exception.ToString());
        }

        private CodeWatchResult AssertThatWatcherThrowException()
        {
            var watcherConfig = TestHelpers.ConfigWithLowerCasePropertyCheck
           .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
           .Build();

            var result = watcherConfig.Execute();
            Assert.IsTrue(result.HasIssues);

            return result;
        }
    }
}