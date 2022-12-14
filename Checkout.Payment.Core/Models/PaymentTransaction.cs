using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Payment.Core.Models.Enums;

namespace Checkout.Payment.Core.Models
{
    public class PaymentTransaction
    {
        [Key]
        [Required]
        public string PaymentId { get; set; }
        [Required]
        public string MerchantId { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public Currencies Currency { get; set; }
        [Required]
        public string CardName { get; set; }
        [Required]
        public string CardNumer { get; set; }
        public DateTime TransactionTime { get; set; }
        public DateTime BankConfirmationTime { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
