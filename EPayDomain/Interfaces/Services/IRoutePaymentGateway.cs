 
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPayDomain.Interfaces.Services
{
   public interface IRoutePaymentGateway
    {
      Task<IPaymentService> GetPaymentServiceAsync(decimal amount);
       

    }
}
