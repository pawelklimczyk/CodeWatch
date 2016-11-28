using System;
using System.Text.RegularExpressions;

namespace Gmtl.CodeWatch.Watchers
{
    class TextBasedWatcher : AbstractWatcher
    {
        private Regex matcher;
        
        public TextBasedWatcher(CodeWatcherContext context) : base(context)
        {
        }

        protected override void CheckType(Type type)
        {
        }
    }
}