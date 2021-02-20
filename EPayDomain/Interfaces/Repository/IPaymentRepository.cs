using EPayDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Interfaces.Repository
{
   public interface IPaymentRepository
    {
        Task<Payment> AddPaymentAsync(Payment model);
    }
}
