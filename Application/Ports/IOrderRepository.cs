using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(string id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task CreateAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(string id);
    }
}
