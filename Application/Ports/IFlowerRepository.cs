using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiHexagonalNet.Application.Ports
{
    public interface IFlowerRepository
    {
        Task<Flower> GetByIdAsync(string id);
        Task<IEnumerable<Flower>> GetAllAsync();
        Task CreateAsync(Flower flower);
        Task UpdateAsync(Flower flower);
        Task DeleteAsync(string id);
    }
}
