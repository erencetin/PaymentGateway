using Checkout.Payment.Core.Interfaces;
using Checkout.Payment.Core.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Checkout.Payment.Infrastructure.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        private PaymentContext _context;
        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public async Task<PaymentTransaction> AddPaymentTransaction(PaymentTransaction paymentTransaction)
        {
            var paymentTransactionResult = await _context.PaymentTransactions.AddAsync(paymentTransaction);
            await _context.SaveChangesAsync();
            return paymentTransactionResult.Entity;
        }

        public async Task<PaymentTransaction> GetPaymentDetailsByPaymentId(string paymentId)
        {
            var paymentResult = await _context.PaymentTransactions
                .Where(p => p.PaymentId == paymentId).SingleOrDefaultAsync();
            return paymentResult;
        }
    }
}
