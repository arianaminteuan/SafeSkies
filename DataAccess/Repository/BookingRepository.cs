using MongoDB.Driver;
using SafeSkies.Models;
using Microsoft.Extensions.Options;
using SafeSkies.DataAccess.Repository.IRepository;

namespace SafeSkies.DataAccess.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IMongoCollection<BookingFlight> _bookingsCollection;

        public BookingRepository(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionURI);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _bookingsCollection = database.GetCollection<BookingFlight>(settings.Value.BookingsCollectionName);
        }

        public async Task AddBookingAsync(BookingFlight booking)
        {
            await _bookingsCollection.InsertOneAsync(booking);
        }

        public async Task<List<BookingFlight>> GetAllBookingsAsync()
        {
            return await _bookingsCollection.Find(_ => true).ToListAsync();
        }
    }
}
