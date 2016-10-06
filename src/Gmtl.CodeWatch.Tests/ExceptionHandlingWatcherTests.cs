using System;
using Gmtl.CodeWatch.Tests.Samples;
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

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }

        [TestCase(typeof(ExceptionTesterWithHandledAndUnhandledException))]
        public void ExceptionHandlingChecker_shouldThrowWhenMethodInAssemlyTypesWithoutProperExcHandlingIsPresent(Type input)
        {
            sut.WatchAssembly(input.Assembly);

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }


        [TestCase(typeof(ExceptionTesterWithInheritedMethod))]
        public void ExceptionHandlingChecker_shouldNotThrowWhenMethodInInParentType(Type input)
        {
            sut.WatchType(input);
            sut.Execute();
        }
    }
}
