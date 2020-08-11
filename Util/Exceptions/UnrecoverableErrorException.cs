using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.Util.Exceptions
{
    class UnrecoverableErrorException : Exception
    {
        public UnrecoverableErrorException(String message) 
            : base(message)
        {
            
        }
    }
}
