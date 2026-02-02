namespace SafeSkies.DataAccess
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string FlightsCollectionName { get; set; } = string.Empty;
        public string UsersCollectionName { get;set; } = string.Empty;
        public string BookingsCollectionName { get; set; } = string.Empty;


    }
}
