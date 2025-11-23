using System.Text.Json.Serialization;

namespace API.Models
{
    public class CreateUserResponse
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
