using System;
using Gmtl.CodeWatch.Tests.Samples.ManyParametersMethods;
using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class MaxMethodParametersWatcherTests
    {
        private MaxMethodParametersWatcher watcher;

        [SetUp]
        public void Setup()
        {
            watcher = new MaxMethodParametersWatcher();
        }


        [TestCase(typeof(ClassWithPrivateMethodHaving3Parameters))]
        [TestCase(typeof(ClassWithPrivateMethodHaving4Parameters))]
        [TestCase(typeof(ClassWithPublicMethodHaving3Parameters))]
        [TestCase(typeof(ClassWithPublicMethodHaving4Parameters))]
        [TestCase(typeof(ClassWithPublicStaticMethodHaving3Parameters))]
        [TestCase(typeof(ClassWithPublicStaticMethodHaving4Parameters))]
        public void MaxMethodParametersWatcher_providedClassShouldFailWithMethodAbove2Parameters(Type type)
        {
            watcher.Configure(2);
            watcher.WatchType(type);

            Assert.Throws<CodeWatchException>(() => watcher.Execute());
        }

        [TestCase(typeof(ClassWithPrivateMethodHaving0Parameters))]
        [TestCase(typeof(ClassWithPrivateMethodHaving1Parameters))]
        [TestCase(typeof(ClassWithPrivateMethodHaving2Parameters))]
        [TestCase(typeof(ClassWithPublicMethodHaving0Parameters))]
        [TestCase(typeof(ClassWithPublicMethodHaving1Parameters))]
        [TestCase(typeof(ClassWithPublicMethodHaving2Parameters))]
        [TestCase(typeof(ClassWithPublicStaticMethodHaving0Parameters))]
        [TestCase(typeof(ClassWithPublicStaticMethodHaving1Parameters))]
        [TestCase(typeof(ClassWithPublicStaticMethodHaving2Parameters))]
        public void MaxMethodParametersWatcher_providedClassWithMethodBelow3ParametersShouldPass(Type type)
        {
            watcher.Configure(2);
            watcher.WatchType(type);

            watcher.Execute();
        }

    }
}
