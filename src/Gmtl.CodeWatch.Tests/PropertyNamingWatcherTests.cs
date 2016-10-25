using System;
using Gmtl.CodeWatch.Tests.Samples.PropertyNaming;
using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class PropertyNamingWatcherTests
    {
        private PropertyNamingWatcher sut;

        [SetUp]
        public void Setup()
        {
            sut = new PropertyNamingWatcher();
        }

        [TestCase(typeof(PropertyNamingPublicLowercase))]
        [TestCase(typeof(PropertyNamingProtectedLowercase))]
        [TestCase(typeof(PropertyNamingPrivateLowercase))]
        public void PropertyNamingWatcherLowerCaseCheck_providedClassShouldPassWithAllLowercaseProperties(Type type)
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchType(type);

            sut.Execute();
        }

        [TestCase(typeof(PropertyNamingPublicLowercase))]
        [TestCase(typeof(PropertyNamingProtectedLowercase))]
        [TestCase(typeof(PropertyNamingPrivateLowercase))]
        public void PropertyNamingWatcherUpperCaseCheck_providedClassShouldFailWithAllLowercaseProperties(Type type)
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(type);

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }

        [TestCase(typeof(PropertyNamingPublicUppercase))]
        [TestCase(typeof(PropertyNamingProtectedUppercase))]
        [TestCase(typeof(PropertyNamingPrivateUppercase))]
        [TestCase(typeof(PropertyNamingStaticPublicUppercase))]
        [TestCase(typeof(PropertyNamingStaticProtectedUppercase))]
        [TestCase(typeof(PropertyNamingStaticPrivateUppercase))]
        public void PropertyNamingWatcherLowerCaseCheck_providedClassShouldFailWithAllUppercaseProperties(Type type)
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchType(type);

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }

        [TestCase(typeof(PropertyNamingPublicUppercase))]
        [TestCase(typeof(PropertyNamingProtectedUppercase))]
        [TestCase(typeof(PropertyNamingPrivateUppercase))]
        [TestCase(typeof(PropertyNamingStaticPublicUppercase))]
        [TestCase(typeof(PropertyNamingStaticProtectedUppercase))]
        [TestCase(typeof(PropertyNamingStaticPrivateUppercase))]
        public void PropertyNamingWatcherUpperCaseCheck_providedClassShouldPassWithAllLowercaseProperties(Type type)
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(type);
            sut.Execute();
        }

        [Test]
        public void PropertyNamingWatcher_providedClassShouldOnlyCheckFieldDeclaredInIt()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(typeof(PropertyNamingInheritance));
            sut.Execute();
        }

        [Test]
        public void PropertyNamingWatcherLowerCaseCheck_providedAssemblyWithMixedNamesShouldFail()
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchAssembly(typeof(Gmtl.CodeWatch.TestData.MixedPropertyNames.Class1).Assembly);

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }

        [Test]
        public void PropertyNamingWatcherLowerCaseCheck_providedAssemblyWithUpperCaseNamesShouldFail()
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly);

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }

        [Test]
        public void PropertyNamingWatcherUpperCaseCheck_providedAssemblyWithUpperCaseNamesShouldPass()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly);

            sut.Execute();
        }

        [Test]
        public void PropertyNamingWatcher_exceptionShouldContainFailingPropertyFullName()
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly);

            var exception = Assert.Throws<CodeWatchException>(() => sut.Execute());
            StringAssert.Contains("Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1.TestProperty", exception.Message);
        }
    }
}