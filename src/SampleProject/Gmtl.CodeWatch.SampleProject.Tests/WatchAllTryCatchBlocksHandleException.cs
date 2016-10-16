using NUnit.Framework;

namespace Gmtl.CodeWatch.SampleProject.Tests
{
    [TestFixture]
    public class WatchAllTryCatchBlocksHandleException
    {
        [Test]
        public void AllTryCatchBlocksInAssembyMustBeHandedl()
        {
            ExceptionHandlingWatcher exceptionHandlingWatcher = new ExceptionHandlingWatcher();
            exceptionHandlingWatcher.WatchAssembly(typeof(DomainModel).Assembly);

            exceptionHandlingWatcher.Execute();
        }
    }
}