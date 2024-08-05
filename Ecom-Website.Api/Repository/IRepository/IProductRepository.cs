using Ecom_Website.Entity.Models.Mongo;
using MongoDB.Bson;

namespace Ecom_Website.Api.Repository.IRepository
{
    public interface IProductRepository
    {
        //create new product
        Task<ObjectId> Create(Product product);
        //get all products
        Task<List<Product>> GetAll();
       
        //get product by productId
        Task<Product> GetProductById(string ProductId);
        Task<bool> UpdateProduct(ObjectId Id, Product product);
        //delete product
        Task<bool> DeleteProduct(ObjectId Id);


    }
}
