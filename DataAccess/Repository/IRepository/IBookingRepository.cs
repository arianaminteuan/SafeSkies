using SafeSkies.Models;

namespace SafeSkies.DataAccess.Repository.IRepository
{
    public interface IBookingRepository
    {
        Task AddBookingAsync(BookingFlight booking);
        Task<List<BookingFlight>> GetAllBookingsAsync();
    }
}
