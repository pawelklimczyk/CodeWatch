using System.Collections.Generic;

namespace Gmtl.CodeWatch
{
    public class LettersMap
    {
        static IReadOnlyDictionary<Naming, char[]> map = new Dictionary<Naming, char[]>
        {
            {Naming.LowerCase, "abcdefghijklmnopqrstuwvxzy".ToCharArray()},
            {Naming.UpperCase, "ABCDEFGHIJKLMNOPQRSTUWVXZY".ToCharArray()},
            {Naming.Underscore, new[]{ '_'}}
        };

        public static IReadOnlyDictionary<Naming, char[]> Map { get { return map; } }
    }
}