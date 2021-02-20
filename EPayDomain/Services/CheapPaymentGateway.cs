using EPayDomain.Interfaces.Services;
using EPayDomain.Model;
using EPayDomain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Services
{
    public class CheapPaymentGateway : ICheapPaymentGateway, IPaymentService
    {
        private decimal minimumAmount = 5; //this is dummy just to mimmic scenerio where a card holder is paying too little amount
    public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest model)
        {
           return await ProcessPaymentWithCheapGateway(model);            
        }

      public async Task<PaymentResponse> ProcessPaymentWithCheapGateway(PaymentRequest model)
        {
            //Default response
            PaymentResponse response = new PaymentResponse()
            {
                Status = (int)Utilities.PaymentStatus.Pending,
                Message = "CheapPayment Processor: Pending",
                Reference = Guid.NewGuid().ToString()
            };

            try
            {
                if (model.Amount < minimumAmount)
                {
                    response.Status = (int)Utilities.PaymentStatus.Failed;
                    response.Message = "CheapPayment Processor: Failed - Amount is too small";

                }
                else
                {
                    response.Status = (int)Utilities.PaymentStatus.Failed;
                    response.Message = "CheapPayment Processor: Processed - Transaction was successful";
                }
            }
            catch(Exception ex)
            {
                response.Status = (int)Utilities.PaymentStatus.Pending;
                response.Message = "CheapPayment Processor: Pending - Try again later";
            }
            

            return await Task.FromResult(response);
        }
    }
}
