using System;
using System.Reflection;

namespace Gmtl.CodeWatch.Watchers
{
    public class MethodReturnTypeWatcher : AbstractWatcher
    {
        private Type expectedType;

        public MethodReturnTypeWatcher(CodeWatcherContext context = null) : base(context) { }

        public void Configure(Type type)
        {
            expectedType = type;
        }

        protected override void CheckType(Type type)
        {
            foreach (MethodInfo mi in type.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static))
            {
                Type actualType = mi.ReturnType;

                if (actualType.IsGenericType)
                {
                    bool genericTypeMatch = actualType.GetGenericTypeDefinition() == expectedType.GetGenericTypeDefinition();

                    bool genericParametersMatch = actualType.GenericTypeArguments.Length == expectedType.GenericTypeArguments.Length;

                    if (genericParametersMatch)
                    {
                        for (int i = 0; i < actualType.GenericTypeArguments.Length; i++)
                        {
                            genericParametersMatch &= ((actualType.GenericTypeArguments[i] == expectedType.GenericTypeArguments[i]) | actualType.GenericTypeArguments[i].IsSubclassOf(expectedType.GenericTypeArguments[i]));
                        }
                    }

                    if (!(genericTypeMatch & genericParametersMatch))
                    {
                        AddIssue(new CodeWatchException(String.Format("Method {0} does not meet MethodReturnType standards. Expected:{1} Actual:{2}", mi.Name, expectedType, mi.ReturnType)));
                    }

                    continue;
                }

                if (expectedType != mi.ReturnType)
                {
                    AddIssue(new CodeWatchException(String.Format("Method {0} does not meet MethodReturnType standards. Expected:{1} Actual:{2}", mi.Name, expectedType, mi.ReturnType)));
                }
            }
        }
    }
}
