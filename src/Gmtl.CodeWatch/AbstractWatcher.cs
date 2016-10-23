using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gmtl.CodeWatch
{
    public abstract class AbstractWatcher : IWatcher
    {
        protected List<Type> typesToCheck = new List<Type>();

        protected List<Assembly> assembliesToCheck = new List<Assembly>();

        protected readonly CodeWatcherContext context;

        protected AbstractWatcher(CodeWatcherContext context)
        {
            this.context = context;
        }

        public void WatchType(Type type)
        {
            typesToCheck.Add(type);
        }

        public void WatchAssembly(Assembly assembly)
        {
            assembliesToCheck.Add(assembly);
        }

        public void Execute()
        {
            foreach (Type type in typesToCheck)
            {
                CheckType(type);
            }

            foreach (var assembly in assembliesToCheck)
            {
                foreach (var type in assembly.GetTypes())
                {
                    CheckType(type);
                }
            }
        }

        protected abstract void CheckType(Type type);
    }
}