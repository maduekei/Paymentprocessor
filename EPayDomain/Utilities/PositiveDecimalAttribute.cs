using System;
using System.ComponentModel.DataAnnotations;

namespace EPayDomain.Utilities
{
   class PositiveDecimalAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (Decimal)value > 0; // ensure it is positive value
        }

    }
}