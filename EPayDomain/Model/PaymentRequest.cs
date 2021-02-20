using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EPayDomain.Utilities;


namespace EPayDomain.Model 
{
    public class PaymentRequest //DTO
    {
              

        [Required(ErrorMessage = "Card Number is required")]
        [RegularExpression(@"([0-9]{4}\s?){4}", ErrorMessage = "Invalid Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Card Holder name is required")]
        public string CardHolder { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Date cannot be in the past")]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [ThreeDigits(ErrorMessage = "Field must be 3 digits only")]
        public string SecurityCode { get; set; }

        [Required]
        [PositiveDecimal(ErrorMessage = "Amount must be positive")]
        public decimal Amount { get; set; }
    }
}

