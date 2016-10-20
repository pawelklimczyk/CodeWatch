using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gmtl.CodeWatch
{
    /// <summary>
    /// Checks if Type contains methods with parameters count more than given.
    /// </summary>
    public class MaxMethodParametersWatcher : AbstractWatcher
    {
        private int maxParametersInMethod = 10;

        private readonly BindingFlags searchFlags = BindingFlags.Public | BindingFlags.DeclaredOnly |
                                                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
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
