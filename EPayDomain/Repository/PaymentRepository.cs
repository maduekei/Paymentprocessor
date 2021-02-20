using EPayDomain.Data;
using EPayDomain.Entities;
using EPayDomain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;


        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddPaymentAsync(Payment model)
        {
            _context.Payment.Add(model);
            await _context.SaveChangesAsync();
            return await Task.FromResult(model);
        }
    }
}

