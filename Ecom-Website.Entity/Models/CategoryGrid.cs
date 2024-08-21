using System.Text.Json.Serialization;

namespace Ecom_Website.DataAccess.Models
{
    public class CategoryGrid
    {
        [JsonPropertyName("title")]
        public string categoryName { get; set; }
        [JsonPropertyName("imageLink")]
        public string CategoryImage { get; set; }


    }
}
