using System;
using System.Reflection;

namespace Gmtl.CodeWatch.Watchers
{
    /// <summary>
    /// Checks if Type contains methods with parameters count more than given.
    /// </summary>
    public class MaxMethodParametersWatcher : AbstractWatcher
    {
        private int maxParametersInMethod = 10;

        private readonly BindingFlags searchFlags = BindingFlags.Public | BindingFlags.DeclaredOnly |
                                                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public MaxMethodParametersWatcher(CodeWatcherContext context = null) : base(context) { }

        protected override void CheckType(Type type)
        {
            foreach (MethodInfo methodInfo in type.GetMethods(searchFlags))
            {
                var parameter = methodInfo.GetParameters();

                if (parameter.Length > maxParametersInMethod)
                {
                    throw new CodeWatchException(
                        string.Format(
                            "Method {0}.{1} does not meet MaxMethodParametersWatcher standards. Parameter limit for method is {2}",
                            type.FullName, methodInfo.Name, this.maxParametersInMethod));
                }
            }
        }

        public void Configure(int newMax)
        {
            this.maxParametersInMethod = newMax;
        }
    }
}
