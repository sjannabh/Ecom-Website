using Ecom_Website.Api.Repository.IRepository;
using Ecom_Website.Entity.Models.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ecom_Website.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _productCollection;
        public ProductRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:Mongo:ConnectionString"]);
            var database = client.GetDatabase("MyDb");
            _productCollection = database.GetCollection<Product>("products");

        }
        public Task<ObjectId> Create(Product product)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Product>> GetAll()
        {
            return await _productCollection.Find(_ => true).Limit(5).ToListAsync();
            
        }

        public async Task<Product> GetProductById(string ProductId)
        {
           return await _productCollection.Find(x => x.product_id == ProductId).FirstOrDefaultAsync();
        }

       

        public Task<bool> UpdateProduct(ObjectId Id, Product product)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteProduct(ObjectId Id)
        {
            throw new NotImplementedException();
        }
    }
}
