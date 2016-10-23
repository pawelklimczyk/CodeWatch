using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gmtl.CodeWatch
{
    public class CodeWatcherConfig
    {
        private CodeWatcherContext context;
        private readonly List<IWatcher> watchers = new List<IWatcher>();
        private readonly List<Assembly> assembliesToCheck = new List<Assembly>();


        private CodeWatcherConfig()
        {
        }

        public static CodeWatcherConfig Create(string confurationXml = "")
        {
            //TODO read config if exists

            return new CodeWatcherConfig { context = new CodeWatcherContext() };
        }

        public CodeWatcherConfig WithWatcher(Func<CodeWatcherContext, IWatcher> func)
        {
            var watcher = func(context);
            watchers.Add(watcher);

            return this;
        }

        public CodeWatcherConfig Build()
        {
            foreach (var assembly in assembliesToCheck)
            {
                foreach (var watcher in watchers)
                {
                    watcher.WatchAssembly(assembly);
                }
            }

            return this;
        }

        public void Execute()
        {
            foreach (var watcher in watchers)
            {
                watcher.Execute();
            }
        }

        public CodeWatcherConfig WatchAssembly(Assembly assembly)
        {
            assembliesToCheck.Add(assembly);

            return this;
        }
    }
}