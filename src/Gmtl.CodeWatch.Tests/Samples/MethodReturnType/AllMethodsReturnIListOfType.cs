using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gmtl.CodeWatch.Tests.Samples.MethodReturnType
{
    class AllMethodsReturnIListOfType
    {
        public IList<Object> GetObjects()
        {
            return new List<Object>();
        }

        public IList<int> GetInts()
        {
            return new List<int>();
        }

        public IList<int> GetEvenInts()
        {
            return GetInts().Where(i => i % 2 == 0).ToList();
        }
    }

    class AllMethodsReturnListOfType
    {        
        public List<Object> GetObjects()
        {
            return new List<Object>();
        }

        public List<int> GetInts()
        {
            return new List<int>();
        }

        public List<int> GetEvenInts()
        {
            return GetInts().Where(i => i % 2 == 0).ToList();
        }
    }

    class AllMethodsReturnPrimitiveTypeOfInt
    {
        public int GetCount1()
        {   
            return 1;
        }

        public int GetCount2()
        {
            return 2;
        }

        public int GetCount3()
        {
            return 3;
        }

    }
}
