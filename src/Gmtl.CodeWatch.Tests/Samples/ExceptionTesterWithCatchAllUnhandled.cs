using System;

namespace Gmtl.CodeWatch.Tests.Samples
{
    public class ExceptionTesterWithCatchAllUnhandled
    {
        public void UnhandledException()
        {
            try
            {
                ThrowException();
            }
            catch
            {

            }
        }

        private void ThrowException()
        {
            throw new Exception();
        }
    }
}