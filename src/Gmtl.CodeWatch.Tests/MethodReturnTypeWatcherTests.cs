using System;
using System.Collections.Generic;
using Gmtl.CodeWatch.Tests.Samples.MethodReturnType;
using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    class MethodReturnTypeWatcherTests
    {
        MethodReturnTypeWatcher sut;

        [SetUp]
        public void Setup()
        {
            sut = new MethodReturnTypeWatcher();
        }

        [TestCase(typeof(IList<object>), typeof(AllMethodsReturnIListOfType))]
        [TestCase(typeof(List<object>), typeof(AllMethodsReturnListOfType))]
        [TestCase(typeof(int), typeof(AllMethodsReturnPrimitiveTypeOfInt))]
        public void MethodReturnTypeWatcherWithIListCheck_TypeWithAllMethodsReturningIList_ShouldHaveZeroIssues(Type expectedType, Type classToTest)
        {
            sut.Configure(typeof(IList<object>));
            sut.WatchType(typeof(AllMethodsReturnIListOfType));

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void MethodReturnTypeWatcherWithIListCheck_TypeWithMethodsReturningVariousTypes_ShouldHave2IssuesIssues()
        {
            sut.Configure(typeof(IList<object>));
            sut.WatchType(typeof(MethodsReturnDifferntLists));

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(2));
        }

    }
}
