using System;

namespace Gmtl.CodeWatch
{
    /// <summary>
    /// Exception used to flag rules violation issue
    /// </summary>
    public class CodeWatchException : Exception
    {
        public CodeWatchException(string message)
            : base(message)
        {
        }
    }
}