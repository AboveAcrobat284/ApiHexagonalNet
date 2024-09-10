using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson; // Asegúrate de tener esta referencia para utilizar ObjectId

namespace ApiHexagonalNet.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders.ToList(); // Convierte a List
        }

        public async Task<Order> GetOrderById(string id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task CreateOrder(Order order)
        {
            // Genera un nuevo ObjectId si el Id está vacío o nulo
            if (string.IsNullOrEmpty(order.Id))
            {
                order.Id = ObjectId.GenerateNewId().ToString();
            }

            await _orderRepository.CreateAsync(order);
        }

        public async Task UpdateOrder(string id, Order order)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder != null)
            {
                // Asegúrate de que el ID de la orden actualizada coincida con el ID existente
                order.Id = id;
                await _orderRepository.UpdateAsync(order);
            }
        }

        public async Task DeleteOrder(string id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}
