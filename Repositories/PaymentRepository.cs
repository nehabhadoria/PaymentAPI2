using Microsoft.EntityFrameworkCore;
using paymentAPI.Data;
using paymentAPI.Models;
using paymentAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace paymentAPI.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentdetailContext _context;

        public PaymentRepository(PaymentdetailContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paymentdetail>> GetAllAsync()
        {
            return await _context.Paymentdetails.ToListAsync();
        }

        public async Task<Paymentdetail> GetByIdAsync(int id)
        {
            return await _context.Paymentdetails.FindAsync(id);
        }

        public async Task AddAsync(Paymentdetail payment)
        {
            await _context.Paymentdetails.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paymentdetail payment)
        {
            _context.Paymentdetails.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await _context.Paymentdetails.FindAsync(id);
            if (payment != null)
            {
                _context.Paymentdetails.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
