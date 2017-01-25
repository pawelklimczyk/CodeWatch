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
        private readonly List<Assembly> assembliesToSkip = new List<Assembly>();

        private readonly List<Type> typesToCheck = new List<Type>();
        private readonly List<Type> typesToSkip = new List<Type>();

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

            foreach (var assembly in assembliesToSkip)
            {
                foreach (var watcher in watchers)
                {
                    watcher.SkipAssembly(assembly);
                }
            }

            foreach (var type in typesToCheck)
            {
                foreach (var watcher in watchers)
                {
                    watcher.WatchType(type);
                }
            }

            foreach (var type in typesToSkip)
            {
                foreach (var watcher in watchers)
                {
                    watcher.SkipType(type);
                }
            }

            return this;
        }
        
        /// <summary>
        /// Executes all configured watchers againts provided assemblies and types
        /// </summary>
        public CodeWatchResult Execute()
        {
            List<CodeWatchException> issues = new List<CodeWatchException>();

            foreach (var watcher in watchers)
            {
                watcher.Execute();

                if (watcher.Issues.Count > 0)
                    issues.AddRange(watcher.Issues);
            }

            return new CodeWatchResult(issues);
        }

        /// <summary>
        /// Adds assembly to list of assemblies to be checked
        /// </summary>
        /// <param name="assembly">Assembly to check</param>
        /// <returns>CodeWatchConfig object</returns>
        public CodeWatcherConfig WatchAssembly(Assembly assembly)
        {
            assembliesToCheck.Add(assembly);

            if (assembliesToSkip.Contains(assembly))
                assembliesToSkip.Remove(assembly);

            return this;
        }

        /// <summary>
        /// Adds assembly to list of assemblies to be skipped
        /// </summary>
        /// <param name="assembly">Assembly to skip check</param>
        /// <returns>CodeWatchConfig object</returns>
        public CodeWatcherConfig SkipAssembly(Assembly assembly)
        {
            assembliesToSkip.Add(assembly);

            if (assembliesToCheck.Contains(assembly))
                assembliesToCheck.Remove(assembly);

            return this;
        }

        public CodeWatcherConfig WatchType(Type type)
        {
            typesToCheck.Add(type);

            if (typesToSkip.Contains(type))
                typesToSkip.Remove(type);

            return this;
        }

        public CodeWatcherConfig SkipType(Type type)
        {
            typesToSkip.Add(type);

            if (typesToCheck.Contains(type))
                typesToCheck.Remove(type);

            return this;
        }
    }
}