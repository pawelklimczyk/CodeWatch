using System;

namespace Gmtl.CodeWatch.Tests.Samples
{
    public class ExceptionTesterWithHandledAndUnhandledException
    {
        public void UnhandledException()
        {
            try
            {
                ThrowException();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

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