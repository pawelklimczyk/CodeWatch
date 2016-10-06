using System;
using Gmtl.CodeWatch.Tests.Samples.FieldNaming;
using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class FieldNamingWatcherTests
    {
        private FieldNamingWatcher sut;

        [SetUp]
        public void Setup()
        {
            sut = new FieldNamingWatcher();
        }

        [TestCase(typeof(FieldNamingPublicUppercase))]
        [TestCase(typeof(FieldNamingProtectedUppercase))]
        [TestCase(typeof(FieldNamingPrivateUppercase))]
        public void FieldNamingWatcherUpperCaseCheck_providedClassShouldPassWithAllUppercaseFields(Type type)
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(type);

            sut.Execute();
        }

        [TestCase(typeof(FieldNamingPublicLowercase))]
        [TestCase(typeof(FieldNamingProtectedLowercase))]
        [TestCase(typeof(FieldNamingPrivateLowercase))]
        public void FieldNamingWatcherUpperCaseCheck_providedClassShouldFailWithAllLowercaseFields(Type type)
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(type);

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }

        [TestCase(typeof(FieldNamingPublicUppercase))]
        [TestCase(typeof(FieldNamingProtectedUppercase))]
        [TestCase(typeof(FieldNamingPrivateUppercase))]
        public void FieldNamingWatcherLowerCaseCheck_providedClassShoulFailWithAllUppercaseFields(Type type)
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchType(type);

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }

        [TestCase(typeof(FieldNamingPublicLowercase))]
        [TestCase(typeof(FieldNamingProtectedLowercase))]
        [TestCase(typeof(FieldNamingPrivateLowercase))]
        public void FieldNamingWatcherLowerCaseCheck_providedClassShouldPassWithAllLowercaseFields(Type type)
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchType(type);
            sut.Execute();
        }

        [Test]
        public void FieldNamingWatcher_providedClassShouldOnlyCheckFieldDeclaredInIt()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(typeof(FieldNamingInheritance));
            sut.Execute();
        }
    }
}