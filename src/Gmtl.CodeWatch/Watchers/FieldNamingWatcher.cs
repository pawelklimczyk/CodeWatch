using System;
using System.Linq;
using System.Reflection;

namespace Gmtl.CodeWatch.Watchers
{
    public class FieldNamingWatcher : AbstractWatcher
    {
        private Naming namingConvention = Naming.UpperCase;
        
        public FieldNamingWatcher(CodeWatcherContext context = null) : base(context) { }

        protected override void CheckType(Type type)
        {
            foreach (FieldInfo pi in type.GetFields(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                char firstLetter = pi.Name[0];

                if (!LettersMap.Map[namingConvention].Contains(firstLetter))
                {
                    AddIssue(new CodeWatchException(String.Format("Field {0} does not meet FieldNaming standards", pi.Name)));
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
