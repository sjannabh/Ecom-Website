using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Ecom_Website.Entity.Models.Mongo
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("fname")]
        public string Fname { get; set; }

        [JsonPropertyName("lname")]
        public string Lname { get; set; }

        [JsonPropertyName("phoneNo")]
        public string PhoneNo { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("product_recommendations")]
        public List<string> ProductRecommendations { get; set; }
    }
}
