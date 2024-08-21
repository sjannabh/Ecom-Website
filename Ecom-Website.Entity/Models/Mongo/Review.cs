using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Ecom_Website.DataAccess.Models.Mongo
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public ObjectId Id { get; set; }

        [BsonElement("product_id")]
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [BsonElement("user_id")]
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [BsonElement("review_id")]
        [JsonPropertyName("review_id")]
        public string ReviewId { get; set; }

        [BsonElement("review_title")]
        [JsonPropertyName("review_title")]
        public string ReviewTitle { get; set; }

        [BsonElement("review_content")]
        [JsonPropertyName("review_content")]
        public string ReviewContent { get; set; }

        [BsonElement("rating")]
        [JsonPropertyName("rating")]
        public double Rating { get; set; }
    }
}
