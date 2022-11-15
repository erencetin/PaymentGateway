using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Payment.Core.Models.Enums;

namespace Checkout.Payment.Core.Models
{
    public class PaymentTransactionResponse
    {
        public string PaymentId { get; set; }
        public string MerchantId { get; set; }
        public string CustomerName { get; set; }
        public string CardName { get; set; }
        public decimal Amount { get; set; }
        public Currencies Currency { get; set; }
        public DateTime TransactionTime { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
