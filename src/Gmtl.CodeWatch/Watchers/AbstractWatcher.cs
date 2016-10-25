using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gmtl.CodeWatch.Watchers
{
    public abstract class AbstractWatcher : IWatcher
    {
        protected List<Type> typesToCheck = new List<Type>();

        protected List<Assembly> assembliesToCheck = new List<Assembly>();

        protected List<CodeWatchException> issuesFound = new List<CodeWatchException>();

        protected readonly CodeWatcherContext context;

        public IReadOnlyList<CodeWatchException> Issues => issuesFound;

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

        public IReadOnlyList<CodeWatchException> Execute()
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

            return Issues;
        }

        protected void AddIssue(CodeWatchException exception)
        {
            issuesFound.Add(exception);
        }

        protected abstract void CheckType(Type type);
    }
}