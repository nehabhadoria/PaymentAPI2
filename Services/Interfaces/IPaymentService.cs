using paymentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace paymentAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Paymentdetail>> GetAllAsync();
        Task<Paymentdetail> GetByIdAsync(int id);
        Task AddAsync(Paymentdetail payment);
        Task UpdateAsync(Paymentdetail payment);
        Task DeleteAsync(int id);
    }
}