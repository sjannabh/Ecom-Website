using Ecom_Website.DataAccess.Models.Mongo;

namespace Ecom_Website.DataAccess.ViewModel
{
    public class ProductCarouselViewModel
    {
        public string? Title { get; set; }

        public string CarouselType { get; set; }
        public int Count { get; set; } = 10;

        public List<Product> ProductList { get; set; }
    }
}
