using System;
using System.Collections.Generic;

namespace Gmtl.CodeWatch
{
    public abstract class AbstractWatcher : IWatcher
    {
        protected List<Type> typesToCheck = new List<Type>();

        public void WatchType(Type type)
        {
            typesToCheck.Add(type);
        }

        public abstract void Execute();
    }

    public interface IWatcher
    {
        void WatchType(Type type);
        void Execute();
    }
}