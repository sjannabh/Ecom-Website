using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Ecom_Website.Entity.Models.Mongo
{
    public class PopularRecommendation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public ObjectId Id { get; set; }

        [JsonPropertyName("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("RecommendedList")]
        public List<string> RecommendedList { get; set; }
    }
}
