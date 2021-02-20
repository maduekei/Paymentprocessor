using EPayDomain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPayDomain.Utilities
{
    public class PaymentResponse
    {
        
                      
        public string Reference { get; set; }

        public int Status { get; set; }

        public string Message { get; set; }

    }
}
