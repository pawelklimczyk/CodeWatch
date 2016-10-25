using System;
using Gmtl.CodeWatch.Tests.Samples.ExceptionTester;
using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class ExceptionHandlingWatcherTests
    {
        ExceptionHandlingWatcher sut;

        [SetUp]
        public void SetUp()
        {
            sut = new ExceptionHandlingWatcher();
        }

        [TestCase(typeof(ExceptionTesterWithCatchAllUnhandled))]
        [TestCase(typeof(ExceptionTesterWithCatchAllHandledException))]
        [TestCase(typeof(ExceptionTesterWithParametrizedCatchExceptionV1))]
        [TestCase(typeof(ExceptionTesterWithParametrizedCatchExceptionV2))]
        [TestCase(typeof(ExceptionTesterWithHandledAndUnhandledException))]
        [TestCase(typeof(ExceptionTesterWithInheritedMethodBase))]
        [TestCase(typeof(ExceptionTesterWithPrivateMethodCatchAllUnhandled))]
        public void ExceptionHandlingChecker_shouldThrowWhenMethodInTypeWithoutProperExcHandlingIsPresent(Type input)
        {
            sut.WatchType(input);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
        }

        [TestCase(typeof(ExceptionTesterWithHandledAndUnhandledException))]
        public void ExceptionHandlingChecker_shouldThrowWhenMethodInAssemlyTypesWithoutProperExcHandlingIsPresent(Type input)
        {
            sut.WatchAssembly(input.Assembly);
            
            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
            StringAssert.Contains("Gmtl.CodeWatch.Tests.Samples.ExceptionTester.ExceptionTesterWithCatchAllHandledException", sut.Issues[0].Message);
            StringAssert.Contains("UnhandledException", sut.Issues[0].Message);
        }

        [TestCase(typeof(ExceptionTesterWithInheritedMethod))]
        public void ExceptionHandlingChecker_shouldNotThrowWhenMethodInInParentType(Type input)
        {
            sut.WatchType(input);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }
    }
}
