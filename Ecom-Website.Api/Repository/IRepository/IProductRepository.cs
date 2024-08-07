using Ecom_Website.Entity.Models.Mongo;
using MongoDB.Bson;

namespace Ecom_Website.Api.Repository.IRepository
{
    public interface IProductRepository
    {
        //create new product
        Task Create(Product product);
        //get all products
        Task<List<Product>> GetAll();
       
        //get product by productId
        Task<Product> GetProductById(string ProductId);
        Task Update(string productId, Product product);
        //delete product
        Task Delete(string productId);


    }
}
