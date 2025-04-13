using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Model.Entities
{
    using Contracts;

    public class Product:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}
