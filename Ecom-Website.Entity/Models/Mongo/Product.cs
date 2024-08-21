using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Ecom_Website.DataAccess.Models.Mongo
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("_id")]
        public string? Id { get; set; }

        [DisplayName("Product Id")]
        [JsonPropertyName("product_id")]
        [BsonElement("product_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("product_name")]
        [BsonElement("product_name")]
        public string ProductName { get; set; }

        [JsonPropertyName("category")]
        [BsonElement("category")]
        public string Category { get; set; }

        [JsonPropertyName("price")]
        [BsonElement("price")]
        public double Price { get; set; }

        [JsonProperty("img_link")]
        [BsonElement("img_link")]
        public string? ImgLink { get; set; }

        [JsonPropertyName("product_link")]
        [BsonElement("product_link")]
        public string? ProductLink { get; set; }

        [JsonPropertyName("product_description")]
        [BsonElement("product_description")]
        public string ProductDescription { get; set; }

        [JsonPropertyName("rating")]
        [BsonElement("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("no_of_ratings")]
        [BsonElement("no_of_ratings")]
        public int NoOfRatings { get; set; }

        [JsonPropertyName("product_recommendations")]
        [BsonElement("product_recommendations")]
        public List<string> ProductRecommendations { get; set; }


    }
}
