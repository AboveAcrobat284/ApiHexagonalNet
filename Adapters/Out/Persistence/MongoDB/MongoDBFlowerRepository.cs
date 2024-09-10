using MongoDB.Driver;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiHexagonalNet.Domain.Settings;
using Microsoft.Extensions.Options;

namespace ApiHexagonalNet.Adapters.Out.Persistence.MongoDB
{
    public class MongoDBFlowerRepository : IFlowerRepository
    {
        private readonly IMongoCollection<Flower> _collection;

        public MongoDBFlowerRepository(IMongoClient mongoClient, IOptions<MongoDBSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Flower>("Flowers");
        }

        public async Task<Flower> GetByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Flower>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(Flower flower)
        {
            await _collection.InsertOneAsync(flower);
        }

        public async Task UpdateAsync(Flower flower)
        {
            await _collection.ReplaceOneAsync(e => e.Id == flower.Id, flower);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(e => e.Id == id);
        }
    }
}
