using System;
using Gmtl.CodeWatch.Tests.Samples.PropertyNaming;
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
        public void PropertyNamingWatcherLowerCaseCheck_providedClassShoulFailWithAllUppercaseProperties(Type type)
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
        public void FieldNamingWatcher_providedClassShouldOnlyCheckFieldDeclaredInIt()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(typeof(PropertyNamingInheritance));
            sut.Execute();
        }
    }
}