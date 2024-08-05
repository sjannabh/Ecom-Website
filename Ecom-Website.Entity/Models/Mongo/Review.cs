using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Ecom_Website.Entity.Models.Mongo
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("review_id")]
        public string ReviewId { get; set; }

        [JsonPropertyName("review_title")]
        public string ReviewTitle { get; set; }

        [JsonPropertyName("review_content")]
        public string ReviewContent { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }
    }
}
