using System;
using System.Reflection;

namespace Gmtl.CodeWatch
{
    public interface IWatcher
    {
        void WatchType(Type type);
        void WatchAssembly(Assembly assembly);

        void Execute();
    }
}