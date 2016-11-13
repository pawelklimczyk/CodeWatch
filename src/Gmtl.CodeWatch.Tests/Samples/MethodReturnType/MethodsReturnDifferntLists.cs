using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmtl.CodeWatch.Tests.Samples.MethodReturnType
{
    class MethodsReturnDifferntLists
    {
        public IEnumerable<Object> GetObjects()
        {
            return new List<Object>();
        }

        public IReadOnlyList<int> GetInts()
        {
            return new List<int>();
        }

        public IList<int> GetEvenInts()
        {
            return GetInts().Where(i => i % 2 == 0).ToList();
        }
    }
}
