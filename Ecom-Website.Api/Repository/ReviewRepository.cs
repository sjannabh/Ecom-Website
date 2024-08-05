using Ecom_Website.Api.Repository.IRepository;
using Ecom_Website.Entity.Models.Mongo;
using MongoDB.Driver;

namespace Ecom_Website.Api.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IMongoCollection<Review> _reviews;

        public ReviewRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:MongoConnection"]);
            var database = client.GetDatabase("MyDb");
            _reviews = database.GetCollection<Review>("reviews");
        }
        public async Task<List<Review>> GetAll()
        {
            var reviewList = await _reviews.Find(_ => true).Limit(1).ToListAsync();
            return reviewList;
        }
    }
}
