// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="ExcludedTypeTests.cs" project="Gmtl.CodeWatch.Tests" date="2016-10-27 16:15">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

using Gmtl.CodeWatch.Tests.Samples.FieldNaming;
using Gmtl.CodeWatch.Watchers;
using NUnit.Framework;

namespace Gmtl.CodeWatch.Tests
{
    [TestFixture]
    public class ExcludedTypeTests
    {
        private FieldNamingFirstLetterWatcher sut;

        [SetUp]
        public void Setup()
        {
            sut = new FieldNamingFirstLetterWatcher();
        }

        [Test]
        public void FieldNamingWatcherLowerCaseCheck_providedClassWithUpperCasePropertiesToBeSkipped_ShouldPass()
        {
            sut.Configure(Naming.LowerCase);
            sut.SkipType(typeof(FieldNamingPublicUppercase));

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void FieldNamingWatcherLowerCaseCheck_providedClassWithUpperCasePropertiesToBeSkippedAndLowerCaseToBeWatchedShoudlPass()
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchType(typeof(FieldNamingPublicLowercase));
            sut.SkipType(typeof(FieldNamingPublicUppercase));

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }

        [Test]
        public void FieldNamingWatcherUpperCaseCheck_providedClassWithUpperCasePropertiesToBeSkippedAndLowerCaseToBeWatchedShoudlFail()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(typeof(FieldNamingPublicLowercase));
            sut.SkipType(typeof(FieldNamingPublicUppercase));

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
        }

        [Test]
        public void FieldNamingWatcherUpperCaseCheck_providedClassWithLowerCasePropertiesToBeSkippedAndThenWatchedShoudlFail()
        {
            sut.Configure(Naming.UpperCase);
            sut.SkipType(typeof(FieldNamingPublicLowercase));
            sut.WatchType(typeof(FieldNamingPublicLowercase));

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.GreaterThan(0));
        }

        [Test]
        public void FieldNamingWatcherUpperCaseCheck_providedClassWithLowerCasePropertiesToBeWatchedAndThenSkippedShoudlPass()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(typeof(FieldNamingPublicLowercase));
            sut.SkipType(typeof(FieldNamingPublicLowercase));

            sut.Execute();

            Assert.That(sut.Issues.Count, Is.EqualTo(0));
        }
    }
}