using Ecom_Website.DataAccess.Models.Mongo;

namespace Ecom_Website.DataAccess.ViewModel
{
    public class ProductDescriptionViewModel
    {
        public Product Product { get; set; }
        public ProductCarouselViewModel ProductCarousel { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
