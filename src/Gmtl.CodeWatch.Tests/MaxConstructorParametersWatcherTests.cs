using System;
using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    public class MaxConstructorParametersWatcherTests
    {
        private MaxConstructorParametersWatcher sut;

        [SetUp]
        public void Setup()
        {
            sut = new MaxConstructorParametersWatcher();
        }

        [TestCase(typeof(ClassWithNoParametersInConstructor))]
        [TestCase(typeof(ClassWith1ParametersInConstructor))]
        [TestCase(typeof(ClassWith3ParametersInConstructor))]
        public void MaxConstructorParametersWatcher_providedClassShouldPassWithParametersBelow5(Type type)
        {
            sut.Configure(4);
            sut.WatchType(type);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }

        [TestCase(typeof(ClassWith5ParametersInConstructor))]
        public void MaxConstructorParametersWatcher_providedClassShouldFailWith5Parameters(Type type)
        {
            sut.Configure(4);
            sut.WatchType(type);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
        }

        #region test classes
        class ClassWithNoParametersInConstructor { }

        class ClassWith1ParametersInConstructor
        {
            public int A;

            public ClassWith1ParametersInConstructor(int a)
            {
                A = a;
            }
        }

        class ClassWith3ParametersInConstructor
        {
            public int A, B, C;

            public ClassWith3ParametersInConstructor(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }
        }

        class ClassWith5ParametersInConstructor
        {
            public int A, B, C, D, E;

            public ClassWith5ParametersInConstructor(int a, int b, int c, int d, int e)
            {
                A = a;
                B = b;
                C = c;
                D = d;
                E = e;
            }
        }
        #endregion
    }
}