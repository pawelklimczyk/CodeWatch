using System;
using System.Collections.Generic;
using System.Linq;

namespace Gmtl.CodeWatch
{
    public class CodeWatchResult
    {
        public CodeWatchResult(IList<CodeWatchException> issues)
        {
            Issues = new List<CodeWatchException>(issues);
        }

        public IReadOnlyList<CodeWatchException> Issues { get; private set; }
        
        public bool HasIssues
        {
            get { return Issues.Count == 0; }
        }

        public override string ToString()
        {
            return Issues.Select(e => e.Message).Aggregate((a, b) => String.Format("{0}\r\n{1}", a, b));
        }
    }
}