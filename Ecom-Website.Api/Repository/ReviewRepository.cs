using Ecom_Website.Api.Repository.IRepository;
using Ecom_Website.Entity.Models.Mongo;
using MongoDB.Driver;

namespace Ecom_Website.Api.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IMongoCollection<Review> _reviewsCollections;

        public ReviewRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:MongoCompass:ConnectionString"]);
            var database = client.GetDatabase("MyDb");
            _reviewsCollections = database.GetCollection<Review>("dummyreviews");
        }

        public async Task Create(Review review)
        {
           await _reviewsCollections.InsertOneAsync(review);
        }


        public async Task<List<Review>> GetAll()
        {
           return await _reviewsCollections.Find(_ => true).Limit(1).ToListAsync();
            
        }

        public async Task<Review> GetReviewById(string productId)
        {
            return await _reviewsCollections.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
           
        }

        public async Task Update(string productId, Review review)
        {
            await _reviewsCollections.ReplaceOneAsync(x=>x.ProductId == productId, review);
        }
        public async Task Delete(string productId)
        {
            await _reviewsCollections.DeleteOneAsync(x=>x.ProductId==productId);
        }
    }
}
