using MongoDB.Driver;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(MongodbService service)
        {
            _userCollection = service.GetCollection<User>("users");
        }

        public async Task CreateUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public Task<bool> DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            var user =await _userCollection.Find(user => user.id == id).FirstOrDefaultAsync();
            return user;
        }

        public Task<User?> GetUserByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>?> GetUsersAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }

        public Task<bool> UpdateUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
