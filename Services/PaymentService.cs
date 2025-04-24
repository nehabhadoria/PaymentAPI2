using paymentAPI.Models;
using paymentAPI.Repositories.Interfaces;
using paymentAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace paymentAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Paymentdetail>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error in GetAllAsync: " + ex.Message);
                return new List<Paymentdetail>();
            }
        }


        public async Task<Paymentdetail> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Paymentdetail payment)
        {
            await _repository.AddAsync(payment);
        }

        public async Task UpdateAsync(Paymentdetail payment)
        {
            await _repository.UpdateAsync(payment);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
