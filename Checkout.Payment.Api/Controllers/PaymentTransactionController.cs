using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Payment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTransactionController : ControllerBase
    {
        private readonly ILogger<PaymentTransactionController> _logger;
        private readonly IPaymentTransactionService _paymentTransactionService;
        public PaymentTransactionController(ILogger<PaymentTransactionController> logger, IPaymentTransactionService paymentService)
        {
            _logger = logger;
            _paymentTransactionService = paymentService;
        }

        public ActionResult GetTransaction(Guid id)
        {
            try
            {
                //TODO: not found case
                var result = _paymentTransactionService.GetPayment(id);
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                //TODO: Return error message
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult SendTransaction([FromBody]PaymentTransaction payment)
        {
            try
            {
                //TODO: Validation
                var result = _paymentTransactionService.SendPayment(payment);
                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                //TODO: return error message
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
