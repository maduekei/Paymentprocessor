using EPayDomain.Interfaces.Services;
using EPayDomain.Model;
using EPayDomain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Services
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway, IPaymentService
    {


        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest model)
        {
           
            return await ProcessPaymentWithExpensiveGateway(model);
           
        }

        public async Task<PaymentResponse> ProcessPaymentWithExpensiveGateway(PaymentRequest model)
        {
            PaymentResponse response = new PaymentResponse()
            {
                Status = (int)Utilities.PaymentStatus.Processed,
                Message = "ExpensivePayment Processor: Success",
                Reference = Guid.NewGuid().ToString()
            };
             return await Task.FromResult(response);
        }

        
    }
}
