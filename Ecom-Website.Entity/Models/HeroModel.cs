using System.Text.Json.Serialization;

namespace Ecom_Website.DataAccess.Models
{
    public class HeroModel
    {
        [JsonPropertyName("ImgLink")]
        public string HeroCarouselImages { get; set; }
    }
}
