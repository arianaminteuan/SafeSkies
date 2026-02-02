using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SafeSkies.Models
{
    public class Flight
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("airline")]
        public string Airline { get; set; } = string.Empty;

        [BsonElement("departure")]
        public string Departure { get; set; } = string.Empty;

        [BsonElement("destination")]
        public string Destination { get; set; } = string.Empty;

        [BsonElement("departureTime")]
        public DateTime DepartureTime { get; set; }

        [BsonElement("arrivalTime")]
        public DateTime ArrivalTime { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("seatsAvailable")]
        public int SeatsAvailable { get; set; }

    }
}
