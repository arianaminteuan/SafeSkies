using SafeSkies.Models;

namespace SafeSkies.DataAccess.Repository.IRepository
{
    public interface IFlightRepository
    {
        List<Flight> GetAll();
        void Create(Flight flight);
        void Add(Flight flight); // Optional alias for Create
        Flight? Get(string id);
        Flight? GetFirstOrDefault(Func<Flight, bool> predicate);
        void Update(string id, Flight flight);
        void Delete(string id);
        void Remove(Flight flight);
    }
}
