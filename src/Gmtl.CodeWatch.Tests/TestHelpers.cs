using Gmtl.CodeWatch.Watchers;

namespace Gmtl.CodeWatch.Tests
{
    internal class TestHelpers
    {
        public static CodeWatcherConfig ConfigWithLowerCasePropertyCheck
        {
            get
            {
                return CodeWatcherConfig.Create().WithWatcher(c => new PropertyNamingFirstLetterWatcher(c).Configure(Naming.LowerCase));
            }
        }
    }
}