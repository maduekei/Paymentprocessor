using EPayDomain.Interfaces.Services;
using EPayDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Services
{
    public class RoutePaymentGateway : IRoutePaymentGateway
    {
        public async Task<IPaymentService> GetPaymentServiceAsync(decimal amount)
        {
            if (amount< 20)
            {
                return new CheapPaymentGateway();

            }
            else if (amount >=20 && amount<=500)
            {
                return new ExpensivePaymentGateway();

            }
            else if (amount > 500)
            {
                return new PremiumPaymentGateway();
            }

           

            throw new ArgumentException("No processor to precess this amount");

        }

        
    }
}
