using EPayDomain.Interfaces.Services;
using EPayDomain.Model;
using EPayDomain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Services
{
    public class PremiumPaymentGateway : IPremiumPaymentGateway, IPaymentService
    {
        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest model)
        {
            PaymentResponse response = new PaymentResponse()
            {
                Status = (int)Utilities.PaymentStatus.Processed,
                Message = "PremiumPayment Processor: Success",
                Reference = Guid.NewGuid().ToString()

            };
        
            return await Task.FromResult(response);
        }
    }
}
