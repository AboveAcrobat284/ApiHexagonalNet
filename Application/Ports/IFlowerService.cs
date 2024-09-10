using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IFlowerService
    {
        Task<List<Flower>> GetAllFlowers();
        Task CreateFlower(Flower flower);
        Task UpdateFlower(string id, Flower flower); // Cambia aquí si es necesario
        Task DeleteFlower(string id);
        Task<Flower> GetFlowerById(string id);
    }
}
