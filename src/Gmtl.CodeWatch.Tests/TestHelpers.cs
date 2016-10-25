using Gmtl.CodeWatch.Watchers;

namespace Gmtl.CodeWatch.Tests
{
    internal class TestHelpers
    {
        public static CodeWatcherConfig ConfigWithLowerCasePropertyCheck
        {
            get
            {
                return CodeWatcherConfig.Create().WithWatcher(c => new PropertyNamingWatcher(c).Configure(Naming.LowerCase));
            }
        }
    }
}