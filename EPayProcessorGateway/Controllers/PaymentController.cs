using EPayDomain.Interfaces.Manager;
using EPayDomain.Model;
using EPayDomain.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;
        public PaymentController(IPaymentManager payment, ILogger logger)
        {
            _payment = payment;
            _logger = logger;
        }

       // [HttpPost("ProcessPayment")]
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
                   _logger.LogError(ex, "An error occured while creating the Db.");

                    return StatusCode(500); // Something went wrong
                }
              
              
            }
            else
            {
                
                _logger.LogWarning("Warning", "Your Model was invalid");
                return BadRequest("Error 400"); // 400
            }


        }

    }
}
