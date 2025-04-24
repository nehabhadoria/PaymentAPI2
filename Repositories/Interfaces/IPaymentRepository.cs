using paymentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace paymentAPI.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Paymentdetail>> GetAllAsync();
        Task<Paymentdetail> GetByIdAsync(int id);
        Task AddAsync(Paymentdetail payment);
        Task UpdateAsync(Paymentdetail payment);
        Task DeleteAsync(int id);
    }
}