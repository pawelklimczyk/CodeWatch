using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gmtl.CodeWatch.Watchers
{
    public class PropertyNamingWatcher : AbstractWatcher
    {
        private Naming namingConvention = Naming.UpperCase;

        private static Dictionary<Naming, char[]> maps = new Dictionary<Naming, char[]>
        {
            {Naming.LowerCase, "abcdefghijklmnopqrstuwvxzy".ToCharArray()},
            {Naming.UpperCase, "ABCDEFGHIJKLMNOPQRSTUWVXZY".ToCharArray()}
        };

        public PropertyNamingWatcher(CodeWatcherContext context = null) : base(context) { }

        protected override void CheckType(Type type)
        {
            foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                char firstLetter = pi.Name[0];

                if (!maps[namingConvention].Contains(firstLetter))
                {
                    AddIssue(new CodeWatchException($"Property {type.FullName}.{pi.Name} does not meet PropertyNaming standards"));
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
