using Ecom_Website.DataAccess.Models.Mongo;
using Ecom_Website.DataAccess.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Ecom_Website.DataAccess.Repository
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
        public async Task<List<Product>> GetProductsByName(string ProductName, int count)
        {

            //var filter = BsonDocument.Parse("{product_name:{'$regex' : 'usb', '$options' : 'i'}}");            
            //var filter = new BsonDocument { { "product_name", new BsonDocument { { "$regex", ProductName }, { "$options", "i" } } } };
            string filter = "{ product_name : { '$regex' : '" + ProductName + "', '$options' : 'i' } }";

            return await _productCollection.Find(filter).Limit(count).ToListAsync();
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
