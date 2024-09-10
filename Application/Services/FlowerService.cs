using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq; // Asegúrate de tener esta referencia para usar ToList()

namespace ApiHexagonalNet.Application.Services
{
    public class FlowerService : IFlowerService
    {
        private readonly IFlowerRepository _flowerRepository;

        public FlowerService(IFlowerRepository flowerRepository)
        {
            _flowerRepository = flowerRepository;
        }

        public async Task<List<Flower>> GetAllFlowers()
        {
            var flowers = await _flowerRepository.GetAllAsync();
            return flowers.ToList(); // Convierte IEnumerable a List
        }

        public async Task CreateFlower(Flower flower)
        {
            await _flowerRepository.CreateAsync(flower);
        }

        public async Task UpdateFlower(string id, Flower flower)
        {
            if (id != flower.Id)
            {
                throw new ArgumentException("El ID proporcionado no coincide con el ID del objeto.");
            }

            await _flowerRepository.UpdateAsync(flower);
        }

        public async Task DeleteFlower(string id)
        {
            await _flowerRepository.DeleteAsync(id);
        }

        public async Task<Flower> GetFlowerById(string id)
        {
            return await _flowerRepository.GetByIdAsync(id);
        }
    }
}
