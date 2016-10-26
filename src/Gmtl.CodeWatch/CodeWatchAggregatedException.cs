using System;
using System.Collections.Generic;
using System.Linq;

namespace Gmtl.CodeWatch
{
    /// <summary>
    /// Keeps a list of CodeWatchExceptions.
    /// The purpose is to throw one exception (CodeWatchAggregatedException) that will contain all code issues aggregated from watchers.
    /// </summary>
    public class CodeWatchAggregatedException : Exception
    {
        private readonly List<CodeWatchException> exceptions = new List<CodeWatchException>();

        public IReadOnlyList<CodeWatchException> Exceptions { get { return exceptions; } }

        public CodeWatchAggregatedException(List<CodeWatchException> exceptions)
        {
            this.exceptions.AddRange(exceptions);
        }

        public void AddException(CodeWatchException exception)
        {
            exceptions.Add(exception);
        }

        public override string ToString()
        {
            return exceptions.Select(e => e.Message).Aggregate((a, b) => String.Format("{0}\r\n{1}", a, b));
        }
    }
}