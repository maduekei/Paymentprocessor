using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EPayDomain.Utilities
{
    public class ThreeDigitsAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {


            return value != null && value.ToString().Length == 3;
        }

           
    }
}
