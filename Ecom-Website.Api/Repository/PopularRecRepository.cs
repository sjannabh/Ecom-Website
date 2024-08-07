using Ecom_Website.Api.Repository.IRepository;
using Ecom_Website.Entity.Models.Mongo;
using MongoDB.Driver;

namespace Ecom_Website.Api.Repository
{
    public class PopularRecRepository : IProductRecRepository

    {
        private readonly IMongoCollection<PopularRecommendation> _popRec;

        public PopularRecRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["COnnectionStrings:MongoCompass:COnnectionString"]);
            var database = client.GetDatabase("MyDb");
            _popRec = database.GetCollection<PopularRecommendation>("dummyProductRec");
        }
        public async Task Create(PopularRecommendation popularRecommendation)
        {
            await _popRec.InsertOneAsync(popularRecommendation);
        }

        public async Task Delete(string id)
        {
            await _popRec.DeleteOneAsync(x=>x.ProductId == id);
        }

        public async Task<List<PopularRecommendation>> GetAll()
        {
            return await _popRec.Find(_=>true).ToListAsync();
        }

        public async Task<PopularRecommendation> GetById(string id)
        {
           return await _popRec.Find(x=>x.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task Update(string id, PopularRecommendation popularRecommendation)
        {
            await _popRec.ReplaceOneAsync(x=>x.ProductId == id, popularRecommendation);
        }
    }
}
