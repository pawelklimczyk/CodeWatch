﻿using System;
using Gmtl.CodeWatch.Tests.Samples.PropertyNaming;
using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class PropertyNamingWatcherTests
    {
        private PropertyNamingFirstLetterWatcher sut;

        [SetUp]
        public void Setup()
        {
            sut = new PropertyNamingFirstLetterWatcher();
        }

        [TestCase(typeof(PropertyNamingPublicLowercase))]
        [TestCase(typeof(PropertyNamingProtectedLowercase))]
        [TestCase(typeof(PropertyNamingPrivateLowercase))]
        public void PropertyNamingWatcherLowerCaseCheck_providedClassShouldPassWithAllLowercaseProperties(Type type)
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchType(type);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }

        [TestCase(typeof(PropertyNamingPublicLowercase))]
        [TestCase(typeof(PropertyNamingProtectedLowercase))]
        [TestCase(typeof(PropertyNamingPrivateLowercase))]
        public void PropertyNamingWatcherUpperCaseCheck_providedClassShouldFailWithAllLowercaseProperties(Type type)
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(type);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
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

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
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

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void PropertyNamingWatcher_providedClassShouldOnlyCheckFieldDeclaredInIt()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(typeof(PropertyNamingInheritance));
            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void PropertyNamingWatcherLowerCaseCheck_providedAssemblyWithMixedNamesShouldFail()
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchAssembly(typeof(Gmtl.CodeWatch.TestData.MixedPropertyNames.Class1).Assembly);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
        }

        [Test]
        public void PropertyNamingWatcherLowerCaseCheck_providedAssemblyWithUpperCaseNamesShouldFail()
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
        }

        [Test]
        public void PropertyNamingWatcherUpperCaseCheck_providedAssemblyWithUpperCaseNamesShouldPass()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void PropertyNamingWatcher_exceptionShouldContainFailingPropertyFullName()
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchAssembly(typeof(Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1).Assembly);

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
            StringAssert.Contains("Gmtl.CodeWatch.TestData.AllUppercaseProperties.Class1.TestProperty", sut.Issues[0].Message);
        }
    }
}