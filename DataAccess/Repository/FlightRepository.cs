using MongoDB.Driver;
using SafeSkies.Models;
using Microsoft.Extensions.Options;
using SafeSkies.DataAccess.Repository.IRepository;

namespace SafeSkies.DataAccess.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IMongoCollection<Flight> _flights;

        public FlightRepository(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionURI);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _flights = database.GetCollection<Flight>(settings.Value.FlightsCollectionName);
        }

        public List<Flight> GetAll()
        {
            var allFlights = _flights.Find(flight => true).ToList();
            Console.WriteLine($"[DEBUG] Found {allFlights.Count} flights from MongoDB.");
            return allFlights;
        }

        public void Create(Flight flight) =>
            _flights.InsertOne(flight);

        public void Add(Flight flight) => 
            Create(flight);

        public Flight Get(string id) =>
            _flights.Find(flight => flight.Id == id).FirstOrDefault();

        public Flight ?GetFirstOrDefault(Func<Flight, bool> predicate) =>
            _flights.AsQueryable().FirstOrDefault(predicate);

        public void Update(string id, Flight flight) =>
            _flights.ReplaceOne(f => f.Id == id, flight);

        public void Delete(string id) =>
            _flights.DeleteOne(f => f.Id == id);

        public void Remove(Flight flight) =>
            _flights.DeleteOne(f => f.Id == flight.Id);
    }
}
