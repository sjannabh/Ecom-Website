using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Ecom_Website.DataAccess.Models
{
    public class LineItem
    {
        public int LineItemId { get; set; }

        [ForeignKey("Cart")]
        [Column(Order = 1)]
        public int CartId { get; set; }
        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Cart? Cart { get; set; }
    }
}
