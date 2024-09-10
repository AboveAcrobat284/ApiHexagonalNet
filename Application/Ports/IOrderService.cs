using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrders(); // Cambiado a List<Order>
        Task<Order> GetOrderById(string id);
        Task CreateOrder(Order order);
        Task UpdateOrder(string id, Order order);
        Task DeleteOrder(string id);
    }
}
