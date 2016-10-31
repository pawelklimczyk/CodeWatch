using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class AggregateExceptionTests
    {
        [Test]
        public void CodeWatchAggregatedException_providedAssemblyWith5ViolatedProperties_shouldReturnAggregateExcWith5SubExceptions()
        {
            var exception = AssertThatWatcherThrowException();

            Assert.That(exception.Exceptions.Count, Is.EqualTo(5));
        }

        [Test]
        public void CodeWatchAggregatedException_ToStringShouldContainSubExceptionDetails()
        {
            var exception = AssertThatWatcherThrowException();

            StringAssert.Contains("Class1", exception.ToString());
        }

        private CodeWatchAggregatedException AssertThatWatcherThrowException()
        {
            var watcherConfig = TestHelpers.ConfigWithLowerCasePropertyCheck
           .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
           .Build();

            return Assert.Throws<CodeWatchAggregatedException>(() => watcherConfig.Execute()); 
        }
    }
}