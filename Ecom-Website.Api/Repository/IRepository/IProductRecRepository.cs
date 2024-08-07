using Ecom_Website.Entity.Models.Mongo;

namespace Ecom_Website.Api.Repository.IRepository
{
    public interface IProductRecRepository
    {
        //create
        Task Create(PopularRecommendation popularRecommendation);

        //getall
        Task<List<PopularRecommendation>> GetAll();
        //get by id
        Task<PopularRecommendation> GetById(string id);
        //update
        Task Update(string id, PopularRecommendation popularRecommendation);

        //delete
        Task Delete(string id);
    }
}
