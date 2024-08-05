using Ecom_Website.Entity.Models.Mongo;

namespace Ecom_Website.Api.Repository.IRepository
{
    public interface IReviewRepository
    {
        public Task<List<Review>> GetAll();
    }
}
