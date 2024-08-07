using Ecom_Website.Entity.Models.Mongo;

namespace Ecom_Website.Api.Repository.IRepository
{
    public interface IUserRepository
    {
        // create user
        Task Create(User user);

        //Get all users
        Task<List<User>> GetAll();

        //Get user by userId
        Task<User> GetById(string userId);

        //Update user
        Task Update(string userId, User user);

        //Delete User
        Task Delete(string userId);
    }
}
