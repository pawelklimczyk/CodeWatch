using System;
using System.Collections.Generic;
using System.Linq;

namespace Gmtl.CodeWatch
{
    public class CodeWatchAggregatedException : Exception
    {
        private readonly List<CodeWatchException> exceptions = new List<CodeWatchException>();

        public IReadOnlyList<CodeWatchException> Exceptions => exceptions;

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
            return exceptions.Select(e => e.Message).Aggregate((a, b) => $"{a}\r\n{b}");
        }
    }
}