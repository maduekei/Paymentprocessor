using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPayDomain.Utilities
{
    class FutureDateAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            

            return value != null && (DateTime)value > DateTime.Now;
        }
    }
}
