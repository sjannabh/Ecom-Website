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
            MongoClient client = new MongoClient(config["ConnectionStrings:MongoCompass:ConnectionString"]);
            var database = client.GetDatabase("MyDb");
            _productCollection = database.GetCollection<Product>("dummyproducts");

        }
        public async Task Create(Product product)
        {
            await _productCollection.InsertOneAsync(product);
        }


        public async Task<List<Product>> GetAll()
        {

            return await _productCollection.Find(_ => true).Limit(5).ToListAsync();
            
        }

        public async Task<Product> GetProductById(string ProductId)
        {
           return await _productCollection.Find(x => x.ProductId == ProductId).FirstOrDefaultAsync();
        } 

        public async Task Update(string productId, Product product)
        {
           await _productCollection.ReplaceOneAsync(x => x.ProductId == productId, product);
        }
        public async Task Delete(string productId)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == productId);

        }
    }
}
