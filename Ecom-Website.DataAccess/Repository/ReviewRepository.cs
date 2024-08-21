using Ecom_Website.DataAccess.Models.Mongo;
using Ecom_Website.DataAccess.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Ecom_Website.DataAccess.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IMongoCollection<Review> _reviewsCollections;

        public ReviewRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:Mongo:ConnectionString"]);
            var database = client.GetDatabase("MyDb");
            _reviewsCollections = database.GetCollection<Review>("reviews");
        }

        public async Task Create(Review review)
        {
            await _reviewsCollections.InsertOneAsync(review);
        }


        public async Task<List<Review>> GetAll(int count)
        {
            return await _reviewsCollections.Find(_ => true).Limit(count).ToListAsync();

        }

        public async Task<Review> GetById(string reviewId)
        {
            return await _reviewsCollections.Find(x => x.ReviewId == reviewId).FirstOrDefaultAsync();
        }

        public async Task<List<Review>> GetReviewByProductId(string productId)
        {
            var filter = Builders<Review>.Filter.Eq(r => r.ProductId, productId);
            return await _reviewsCollections.Find(filter).ToListAsync();

        }

        public async Task Update(string productId, Review review)
        {
            await _reviewsCollections.ReplaceOneAsync(x => x.ProductId == productId, review);
        }
        public async Task Delete(string productId)
        {
            await _reviewsCollections.DeleteOneAsync(x => x.ProductId == productId);
        }
    }
}
