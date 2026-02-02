using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SafeSkies.Models
{
    public class OrderDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        [Required]
        public required string OrderHeaderId { get; set; }

        [Required]
        public required string FlightId { get; set; }

        [Required]
        public required int Quantity { get; set; } = 1;

        [Required]
        public double Price { get; set; } 
    }
}
