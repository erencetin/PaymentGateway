using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Payment.Core.Models;

namespace Checkout.Payment.Core.Interfaces
{
    public interface IPaymentTransactionService
    {
        Task<PaymentTransactionResponse> GetPayment(string paymentId);
        Task<PaymentTransactionResponse> SendPayment(PaymentTransactionRequest payment);
    }   
}
