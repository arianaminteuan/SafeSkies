namespace SafeSkies.Models
{
    public class BookingFlight
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Passengers { get; set; }
        public string TravelClass { get; set; }
 /* public BookingFlight(string departure, string arrival, DateTime departureDate, int passengers, string travelClass, DateTime? returnDate = null)
    {
        Departure = departure;
        Arrival = arrival;
        DepartureDate = departureDate;
        ReturnDate = returnDate;
        Passengers = passengers;
        TravelClass = travelClass;
    }*/
   }
  
}
