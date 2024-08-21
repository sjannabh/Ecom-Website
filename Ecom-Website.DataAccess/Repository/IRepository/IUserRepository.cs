using Ecom_Website.DataAccess.Models.Mongo;

namespace Ecom_Website.DataAccess.Repository.IRepository
{
    public interface IUserRepository
    {
        // create user
        Task Create(User user);

        //Get all users
        Task<List<User>> GetAll();

        //Get user by userId
        Task<User> GetById(string userId);
        Task<User> GetByIdEmail(string email);

        //Update user
        Task Update(string userId, User user);

        //Delete User
        Task Delete(string userId);
    }
}
