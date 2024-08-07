using Ecom_Website.Entity.Models.Mongo;

namespace Ecom_Website.Api.Repository.IRepository
{
    public interface IReviewRepository
    {
        // create
        Task Create(Review review);
        //Get all reviews
        Task<List<Review>> GetAll();

        //get by productid
        Task<Review> GetReviewById(string productId);

        //Update product
        Task Update(string productId, Review review);   

        //Delete Review
        Task Delete(string productId);
    }
}
