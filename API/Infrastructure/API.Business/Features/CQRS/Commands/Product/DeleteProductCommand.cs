using MediatR;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Business.Features.CQRS.Commands.Product
{
    public class DeleteProductCommand(string id) : IRequest<bool>
    {
        [BsonId]
        public string Id { get; set; } = id;
    }
}
