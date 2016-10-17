using System;

namespace Gmtl.CodeWatch.Tests.Samples.ExceptionTester
{
    public class ExceptionTesterWithParametrizedCatchExceptionV1
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