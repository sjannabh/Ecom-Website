using Ecom_Website.Api.Repository.IRepository;
using Ecom_Website.Entity.Models.Mongo;
using MongoDB.Driver;

namespace Ecom_Website.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["ConnectionStrings:MongoCompass:ConnectionString"]);
            var database = client.GetDatabase("MyDb");
            _userCollection = database.GetCollection<User>("dummyusers");
        }
        public async Task Create(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task Delete(string userId)
        {
            await _userCollection.DeleteOneAsync(x=>x.UserId == userId);
        }

        public async Task<List<User>> GetAll()
        {
            var response = await _userCollection.Find(_ => true).ToListAsync();
            return response;
        }

        public async Task<User> GetById(string userId)
        {
            return await _userCollection.Find(x=>x.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task Update(string userId, User user)
        {
            await _userCollection.ReplaceOneAsync(x=>x.UserId == userId, user);
        }
    }
}
