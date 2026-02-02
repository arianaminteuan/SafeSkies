using AspNetCore.Identity.Mongo.Model;

namespace SafeSkies.Models.ViewModels
{
    public class ApplicationUser : MongoUser
    {
        public string FullName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Role { get; set; }
    }
}
