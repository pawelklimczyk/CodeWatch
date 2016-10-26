using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gmtl.CodeWatch
{
    public interface IWatcher
    {
        /// <summary>
        /// Add particular Type to be checked by watcher
        /// </summary>
        /// <param name="type">Type to be checked</param>
        void WatchType(Type type);

        /// <summary>
        /// Add particular Assembly to be checked by watcher
        /// </summary>
        /// <param name="assembly">Assembly to be checked</param>
        void WatchAssembly(Assembly assembly);

        /// <summary>
        /// Executed watcher code check
        /// </summary>
        /// <returns>List of issues found by watcher</returns>
        IReadOnlyList<CodeWatchException> Execute();

        /// <summary>
        /// Contain list of issues populated with Execute() method
        /// </summary>
        IReadOnlyList<CodeWatchException> Issues { get; }
    }
}