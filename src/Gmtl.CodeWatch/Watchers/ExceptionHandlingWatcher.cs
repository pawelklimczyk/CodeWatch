using System;
using System.Linq;
using System.Reflection;

namespace Gmtl.CodeWatch.Watchers
{
    public class ExceptionHandlingWatcher : AbstractWatcher
    {
        private static Type objType = typeof(Object);

        public ExceptionHandlingWatcher(CodeWatcherContext context = null) : base(context) { }

        protected override void CheckType(Type type)
        {
            foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                var methodBody = methodInfo.GetMethodBody();
                if (methodBody == null) continue;

                foreach (var excHandCauses in methodBody.ExceptionHandlingClauses.Where(c => c.Flags != ExceptionHandlingClauseOptions.Finally))
                {
                    if (excHandCauses.CatchType == objType)
                    {
                        AddIssue(new CodeWatchException(String.Format("Method {0} in type {1} has catch-all exception handler", methodInfo.Name, type.FullName)));
                    }
                    else if (excHandCauses.HandlerLength <= 6)
                    {
                        AddIssue(new CodeWatchException(String.Format("Method {0} in type {1} does not handle exception in catch clause", methodInfo.Name, type.FullName)));
                    }
                }
            }
        }
    }
}