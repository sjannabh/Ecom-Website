using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom_Website.DataAccess.Models
{
    public class Cart
    {

        [Key]
        [Column(Order = 1)]
        public int CartId { get; set; }
        public string? UserId { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public int Count { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }


    }
}
