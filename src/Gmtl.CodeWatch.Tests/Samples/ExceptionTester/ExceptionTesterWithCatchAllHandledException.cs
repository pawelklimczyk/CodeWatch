using System;

namespace Gmtl.CodeWatch.Tests.Samples.ExceptionTester
{
    public class ExceptionTesterWithCatchAllHandledException
    {
        public void UnhandledException()
        {
            try
            {
                ThrowException();
            }
            catch
            {
                Console.WriteLine("Exception");
            }
        }

        private void ThrowException()
        {
            throw new Exception();
        }
    }
}