using EPayDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Interfaces.Repository
{
   public interface IPaymentTransactionRepository
    {
        Task<PaymentTransaction> AddResponseAsync(PaymentTransaction model);
    }
}
