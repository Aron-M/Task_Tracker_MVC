using System.Text.Json.Serialization;

namespace TaskTrackerMVC.Models
{
    public class UserModel
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        // Add other user properties as needed, with [JsonPropertyName] attributes
    }
}