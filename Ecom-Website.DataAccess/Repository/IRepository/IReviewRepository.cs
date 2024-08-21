using Ecom_Website.DataAccess.Models.Mongo;

namespace Ecom_Website.DataAccess.Repository.IRepository
{
    public interface IReviewRepository
    {
        // create
        Task Create(Review review);
        //Get all reviews
        Task<List<Review>> GetAll(int count);

        //get by id
        Task<Review> GetById(string reviewId);

        //get list of reviews by productid
        Task<List<Review>> GetReviewByProductId(string productId);

        //Update product
        Task Update(string productId, Review review);

        //Delete Review
        Task Delete(string productId);
    }
}
