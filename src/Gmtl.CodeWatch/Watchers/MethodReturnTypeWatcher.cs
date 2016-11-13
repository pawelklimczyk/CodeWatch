using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmtl.CodeWatch.Watchers
{
    public class MethodReturnTypeWatcher : AbstractWatcher
    {
        public MethodReturnTypeWatcher(CodeWatcherContext context = null) : base(context) { }

        protected override void CheckType(Type type)
        {
           // throw new NotImplementedException();
        }

        public void Configure(Type expectedType)
        {

        }
    }
}
