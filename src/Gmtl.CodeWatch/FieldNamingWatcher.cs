using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gmtl.CodeWatch
{
    public class FieldNamingWatcher : AbstractWatcher
    {
        private Naming namingConvention = Naming.UpperCase;

        private static Dictionary<Naming, char[]> maps = new Dictionary<Naming, char[]>
        {
            {Naming.LowerCase, "abcdefghijklmnopqrstuwvxzy".ToCharArray()},
            {Naming.UpperCase, "ABCDEFGHIJKLMNOPQRSTUWVXZY".ToCharArray()}
        };

        public FieldNamingWatcher(CodeWatcherContext context = null) : base(context) { }

        protected override void CheckType(Type type)
        {
            foreach (FieldInfo pi in type.GetFields(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
            {
                char firstLetter = pi.Name[0];

                if (!maps[namingConvention].Contains(firstLetter))
                {
                    throw new CodeWatchException(String.Format("Field {0} does not meet FieldNaming standards", pi.Name));
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
