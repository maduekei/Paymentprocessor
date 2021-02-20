using EPayDomain.Model;
using EPayDomain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Interfaces.Manager
{
  public  interface IPaymentManager
    {

        Task<PaymentResponse> ProcessPaymentAsyc(PaymentRequest model);

    }
}
