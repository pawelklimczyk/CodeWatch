using System;
using System.Reflection;

namespace Gmtl.CodeWatch.Watchers
{
    public class MaxConstructorParametersWatcher : AbstractWatcher
    {
        private int maxParametersInConstroctur = 4;

        private readonly BindingFlags searchFlags = BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static;

        public MaxConstructorParametersWatcher(CodeWatcherContext context = null) : base(context) { }

        protected override void CheckType(Type type)
        {
           
            foreach (ConstructorInfo constructorInfo in type.GetConstructors(searchFlags))
            {
                var parameter = constructorInfo.GetParameters();

                if (parameter.Length > maxParametersInConstroctur)
                {
                    AddIssue(new CodeWatchException(String.Format("Constructor {0}.{1} does not meet MaxConstructorParametersWatcher standards. Parameter limit for constructor is {2}", type.FullName, constructorInfo.Name, maxParametersInConstroctur)));
                }
            }
        }

        /// <summary>
        /// Confugure how much maximum parameters can constructor
        /// </summary>
        /// <param name="newMaxParametersCount">max number of parameters</param>
        /// <returns>watcher</returns>
        public AbstractWatcher Configure(int newMaxParametersCount)
        {
            maxParametersInConstroctur = newMaxParametersCount;

            return this;
        }
    }
}