using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class AggregateExceptionTests
    {
        [Test]
        public void CodeWatchAggregatedException_providedAssemblyWith5ViolatedProperties_shouldReturnAggregateExcWith5SubExceptions()
        {
            var watcherConfig = TestHelpers.ConfigWithLowerCasePropertyCheck
                .WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly)
                .Build();

            var exception = Assert.Throws<CodeWatchAggregatedException>(() => watcherConfig.Execute());

            Assert.That(exception.Exceptions.Count, Is.EqualTo(5));
        }
    }
}