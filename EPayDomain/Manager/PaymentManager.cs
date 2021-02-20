using AutoMapper;
using EPayDomain.Entities;
using EPayDomain.Interfaces.Manager;
using EPayDomain.Interfaces.Repository;
using EPayDomain.Interfaces.Services;
using EPayDomain.Model;
using EPayDomain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Manager
{
    public class PaymentManager : IPaymentManager
    {
         
        private readonly IRoutePaymentGateway _rout;
        private readonly IPaymentRepository _payment;
        private readonly IPaymentTransactionRepository _paymenttransaction;
        private readonly IMapper _mapper;

        public PaymentManager(IRoutePaymentGateway rout, IPaymentRepository payment, IPaymentTransactionRepository paymenttransaction ,IMapper mapper)
        {
            _rout = rout;
            _payment = payment;
            _paymenttransaction = paymenttransaction;
            _mapper = mapper; //Automapper Imaper object
        }

        public async Task<PaymentResponse> ProcessPaymentAsyc(PaymentRequest model)
        {
           var paymentservice = await _rout.GetPaymentServiceAsync(model.Amount); // this will select which payment provider/processor to use based on the amount to pay
           var response=  await paymentservice.ProcessPaymentAsync(model); 

             // The payment and PaymentTransaction payload must be saved to database
            //Step 1. Save or persist the payment payload       
            var payment =  _mapper.Map<Payment>(model); // Automaper in action here
            await _payment.AddPaymentAsync(payment); // Save Payment

            //Sep 2. Save or persist the response payload  
            var pr = _mapper.Map<PaymentTransaction>(response);

            var paymentResponse = _paymenttransaction.AddResponseAsync(pr);
          

            return response;  // await Task.FromResult(paymentresponse);
        }
    }
}
