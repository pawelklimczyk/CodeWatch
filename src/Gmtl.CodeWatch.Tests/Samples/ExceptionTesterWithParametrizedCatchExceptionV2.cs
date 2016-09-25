﻿using System;

namespace Gmtl.CodeWatch.Tests.Samples
{
    public class ExceptionTesterWithParametrizedCatchExceptionV2
    {
        public void UnhandledException()
        {
            try
            {
                ThrowException();
            }
            catch (Exception)
            {
            }
        }

        private void ThrowException()
        {
            throw new Exception();
        }
    }
}