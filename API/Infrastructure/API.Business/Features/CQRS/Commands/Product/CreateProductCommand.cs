using MediatR;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Business.Features.CQRS.Commands.Product
{
    public class CreateProductCommand : IRequest<bool>
    {
        [BsonId]
        public string CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }
    }
}
