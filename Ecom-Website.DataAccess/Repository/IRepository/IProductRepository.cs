using Ecom_Website.DataAccess.Models.Mongo;

namespace Ecom_Website.DataAccess.Repository.IRepository
{
    public interface IProductRepository
    {
        //create new product
        Task Create(Product product);
        //get all products
        Task<List<Product>> GetAll();

        //get product by productId
        Task<Product> GetProductById(string ProductId);

        Task<List<Product>> GetProductsByName(string ProductName, int count);
        Task Update(string productId, Product product);
        //delete product
        Task Delete(string productId);


    }
}
