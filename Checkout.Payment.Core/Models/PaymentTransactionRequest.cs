using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Payment.Core.Models.Enums;

namespace Checkout.Payment.Core.Models
{
    public class PaymentTransactionRequest
    {
        [Required]
        public string MerchantId { get; set; }
        [MaxLength(60)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(60)]
        public string CardName { get; set; }
        [Required]
        [MaxLength(16)]
        public string CardNumber { get; set; }
        [Required]
        public int Cvv { get; set; }
        public DateTime ExpireDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public Currencies Currency { get; set; }
        [Required]
        public DateTime TransactionTime { get; set; }
    }
}
