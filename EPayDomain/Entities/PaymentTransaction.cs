using EPayDomain.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPayDomain.Entities
{
    public class PaymentTransaction
    {      
        
      
        public int Id { get; set; }

       
        public string Reference { get; set; }

        public int Status { get; set; }

        public string Message { get; set; }
    }
}
