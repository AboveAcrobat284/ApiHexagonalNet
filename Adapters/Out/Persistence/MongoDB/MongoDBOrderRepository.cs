using MongoDB.Driver;
using ApiHexagonalNet.Application.Ports;
using ApiHexagonalNet.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiHexagonalNet.Domain.Settings;
using Microsoft.Extensions.Options;

namespace ApiHexagonalNet.Adapters.Out.Persistence.MongoDB
{
    public class MongoDBOrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;

        public MongoDBOrderRepository(IMongoClient mongoClient, IOptions<MongoDBSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Order>("Orders");
        }

        public async Task<Order> GetByIdAsync(string id)
        {
            return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task CreateAsync(Order order)
        {
            await _collection.InsertOneAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            await _collection.ReplaceOneAsync(e => e.Id == order.Id, order);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(e => e.Id == id);
        }
    }
}
