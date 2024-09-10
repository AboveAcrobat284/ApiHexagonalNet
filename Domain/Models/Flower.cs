using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiHexagonalNet.Domain.Models
{
    public class Flower
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } // Hacer el Id opcional

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
