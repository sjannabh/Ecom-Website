using Ecom_Website.DataAccess.Models;
using Ecom_Website.DataAccess.Models.Mongo;

namespace Ecom_Website.DataAccess.ViewModel
{
    public class HomeViewModel
    {
        public User? user { get; set; }
        public List<HeroModel> heroList { get; set; }
        public List<CategoryGrid> CategoryGrid { get; set; }

        public ProductCarouselViewModel Carousel { get; set; }
    }
}
