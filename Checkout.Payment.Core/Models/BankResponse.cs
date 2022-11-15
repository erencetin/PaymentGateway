using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Checkout.Payment.Core.Models.Enums;

namespace Checkout.Payment.Core.Models
{
    public class BankResponse
    {
        public string PaymentTransactionId { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime ConfirmationTime { get; set; }
    }
}
