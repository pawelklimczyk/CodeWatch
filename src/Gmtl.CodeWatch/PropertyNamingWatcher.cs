using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gmtl.CodeWatch
{
    public class PropertyNamingWatcher : AbstractWatcher
    {
        private Naming namingConvention = Naming.UpperCase;

        private static Dictionary<Naming, char[]> maps = new Dictionary<Naming, char[]>
        {
            {Naming.LowerCase, "abcdefghijklmnopqrstuwvxzy".ToCharArray()},
            {Naming.UpperCase, "ABCDEFGHIJKLMNOPQRSTUWVXZY".ToCharArray()}
        };
        
        public override void Execute()
        {
            foreach (Type type in typesToCheck)
            {
                foreach (PropertyInfo pi in type.GetProperties())
                {
                    char firstLetter = pi.Name[0];

                    if(!maps[namingConvention].Contains(firstLetter))
                    {
                        throw new CodeWatchException(String.Format("Property {0} does not meet PropertyNaming standards", pi.Name));
                    }
                }
            }
        }

        public void Configure(Naming convention)
        {
            namingConvention = convention;
        }
    }

    public enum Naming
    {
        UpperCase,
        LowerCase
    }
}
