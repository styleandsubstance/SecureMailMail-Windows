using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.Util.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(String message) 
            : base(message)
        {
            
        }
    }
}
