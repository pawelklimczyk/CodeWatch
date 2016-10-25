using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gmtl.CodeWatch
{
    public interface IWatcher
    {
        void WatchType(Type type);
        void WatchAssembly(Assembly assembly);

        IReadOnlyList<CodeWatchException> Execute();
        IReadOnlyList<CodeWatchException> Issues { get; }
    }
}