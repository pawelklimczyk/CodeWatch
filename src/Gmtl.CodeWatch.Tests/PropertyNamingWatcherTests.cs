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

        [Test]
        public void PropertyNamingWatcherLowerCaseCheck_providedClassShouldPassWithAllLowercaseProperties()
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchType(typeof(PropertyNamingLowercase));

            sut.Execute();
        }

        [Test]
        public void PropertyNamingWatcherUpperCaseCheck_providedClassShouldFailWithAllLowercaseProperties()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(typeof(PropertyNamingLowercase));

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }

        [Test]
        public void PropertyNamingWatcherLowerCaseCheck_providedClassShoulFailWithAllUppercaseProperties()
        {
            sut.Configure(Naming.LowerCase);
            sut.WatchType(typeof(PropertyNamingUppercase));

            Assert.Throws<CodeWatchException>(() => sut.Execute());
        }

        [Test]
        public void PropertyNamingWatcherUpperCaseCheck_providedClassShouldPassWithAllLowercaseProperties()
        {
            sut.Configure(Naming.UpperCase);
            sut.WatchType(typeof(PropertyNamingUppercase));
            sut.Execute();
        }
    }
}