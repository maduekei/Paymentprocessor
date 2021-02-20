using EPayDomain.Data;
using EPayDomain.Entities;
using EPayDomain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Repository
{
    public class PaymentTransactionRepository : IPaymentTransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentTransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaymentTransaction> AddResponseAsync(PaymentTransaction model)
        {
           _context.PaymentTransaction.Add(model);
           await _context.SaveChangesAsync();
           return await Task.FromResult( model);
        }
    }
}
