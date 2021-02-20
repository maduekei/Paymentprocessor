using EPayDomain.Interfaces.Manager;
using EPayDomain.Model;
using EPayDomain.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPayProcessorGateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentManager _payment;
       
        public PaymentController(IPaymentManager payment)
        {
            _payment = payment;
             
        }

       
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _payment.ProcessPaymentAsyc(model);
                    return Ok(response); // 200
                }
                catch (Exception ex)
                {
                   // 
                     

                    return StatusCode(500); // Something went wrong
                }
              
              
            }
            else
            {
                
                
                return BadRequest("Error 400"); // 400
            }


        }

    }
}
