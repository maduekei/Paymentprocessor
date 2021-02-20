using EPayDomain.Model;
using EPayDomain.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest model);
    }
}
