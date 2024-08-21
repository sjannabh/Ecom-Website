using Ecom_Website.DataAccess.Models.Mongo;
using Ecom_Website.DataAccess.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Ecom_Website.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:Mongo:ConnectionString"]);
            var database = client.GetDatabase("MyDb");
            _userCollection = database.GetCollection<User>("users");
        }
        public async Task Create(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task Delete(string userId)
        {
            await _userCollection.DeleteOneAsync(x => x.UserId == userId);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userCollection.Find(_ => true).ToListAsync();

        }

        public async Task<User> GetById(string userId)
        {
            return await _userCollection.Find(x => x.UserId == userId).FirstOrDefaultAsync();
        }
        public async Task<User> GetByIdEmail(string email)
        {
            return await _userCollection.Find(x => x.Email == email).FirstOrDefaultAsync();
        }


        public async Task Update(string userId, User user)
        {
            await _userCollection.ReplaceOneAsync(x => x.UserId == userId, user);
        }
    }
}
