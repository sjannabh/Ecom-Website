using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Ecom_Website.DataAccess.Models.Mongo
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [BsonElement("fname")]
        [JsonPropertyName("fname")]
        public string Fname { get; set; }

        [BsonElement("lname")]
        [JsonPropertyName("lname")]
        public string Lname { get; set; }

        [BsonElement("phoneNo")]
        [JsonPropertyName("phoneNo")]
        public string PhoneNo { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [BsonElement("product_recommendations")]
        [JsonPropertyName("product_recommendations")]
        public string[] ProductRecommendations { get; set; }
    }
}
