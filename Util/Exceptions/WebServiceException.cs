using System;
using System.Collections.Generic;
using System.Text;

namespace SecureMedMail.Util.Exceptions
{
    class WebServiceException : Exception
    {
        public WebServiceException(String message)
            : base(message)
        {
            
        }
    }
}
