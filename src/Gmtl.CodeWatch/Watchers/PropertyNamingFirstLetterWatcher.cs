using System;
using System.Linq;
using System.Reflection;

namespace Gmtl.CodeWatch.Watchers
{
    public class PropertyNamingFirstLetterWatcher : AbstractWatcher
    {
        private Naming namingConvention = Naming.UpperCase;
        
        public PropertyNamingFirstLetterWatcher(CodeWatcherContext context = null) : base(context) { }

        protected override void CheckType(Type type)
        {
            foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                char firstLetter = pi.Name[0];

                if (!LettersMap.Map[namingConvention].Contains(firstLetter))
                {
                    AddIssue(new CodeWatchException(String.Format("Property {0}.{1} does not meet PropertyNamingFirstLetter standards", type.FullName, pi.Name)));
                }
            }
        }

        public AbstractWatcher Configure(Naming convention)
        {
            namingConvention = convention;

            return this;
        }
    }
}
