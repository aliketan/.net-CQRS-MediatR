using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Model.Entities
{
    using Contracts;

    public class Category:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [BsonIgnore]
        public ICollection<Product> Product { get; set; }
    }
}
