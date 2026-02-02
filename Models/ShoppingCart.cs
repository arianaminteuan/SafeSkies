using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SafeSkies.Models
{
    public class ShoppingCart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        public required string UserId { get; set; }

        public required string FlightId { get; set; }

        public int Quantity { get; set; }
    }
}
