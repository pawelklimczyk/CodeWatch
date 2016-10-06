using System;

namespace Gmtl.CodeWatch.Tests.Samples.ExceptionTester
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

    public class ExceptionTesterWithPrivateMethodCatchAllUnhandled
    {
        public void PublicMethod()
        {
            UnhandledException();
        }

        private void UnhandledException()
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