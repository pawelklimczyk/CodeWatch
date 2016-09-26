using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gmtl.CodeWatch
{
    public class ExceptionHandlingWatcher
    {
        private List<Type> typesToCheck = new List<Type>();
        private List<Assembly> assembliesToCheck = new List<Assembly>();
        private static Type objType = typeof(Object);

        public void WatchType(Type type)
        {
            typesToCheck.Add(type);
        }

        public void Execute()
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
        }

        private static void CheckType(Type type)
        {
            foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                var methodBody = methodInfo.GetMethodBody();
                if (methodBody == null) continue;

                foreach (var excHandCauses in methodBody.ExceptionHandlingClauses.Where(c=>c.Flags!=ExceptionHandlingClauseOptions.Finally))
                {
                    if (excHandCauses.CatchType == objType)
                    {
                        throw new CodeWatchException(String.Format("Method {0} has catch-all exception handler", methodInfo.Name));
                    }

                    if (excHandCauses.HandlerLength <= 6)
                    {
                        throw new CodeWatchException(String.Format("Method {0} does not handle exception in catch clause", methodInfo.Name));
                    }
                }
            }
        }

        public void WatchAssembly(Assembly assembly)
        {
            assembliesToCheck.Add(assembly);
        }
    }
}