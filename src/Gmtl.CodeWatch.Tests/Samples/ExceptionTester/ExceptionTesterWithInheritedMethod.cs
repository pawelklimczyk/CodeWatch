using System;

namespace Gmtl.CodeWatch.Tests.Samples.ExceptionTester
{
    public class ExceptionTesterWithInheritedMethod : ExceptionTesterWithInheritedMethodBase
    {

    }

    public class ExceptionTesterWithInheritedMethodBase
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