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
                        AddIssue(new CodeWatchException($"Method {methodInfo.Name} in type {type.FullName} has catch-all exception handler"));
                    }
                    else if (excHandCauses.HandlerLength <= 6)
                    {
                        AddIssue(new CodeWatchException($"Method {methodInfo.Name} in type {type.FullName} does not handle exception in catch clause"));
                    }
                }
            }
        }
    }
}