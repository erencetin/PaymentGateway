using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Payment.Core.Models;

namespace Checkout.Payment.Core.Interfaces
{
    public interface IPaymentRepository
    {
        Task<PaymentTransaction> AddPaymentTransaction(PaymentTransaction paymentTransaction);
        Task<PaymentTransaction> GetPaymentDetailsByPaymentId(string paymentId);
    }
}
