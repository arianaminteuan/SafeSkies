using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SafeSkies.Models
{
    public class OrderHeader
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        public required string UserId { get; set; }

        public required string FullName { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public double TotalAmount { get; set; }

        public string? Status { get; set; } = "Pending"; 

        public string? PaymentStatus { get; set; } = "Unpaid"; 

        public List<OrderDetail>? Details { get; set; }
    }
}
