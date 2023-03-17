using Microsoft.Extensions.Options;
using MongoDB.Driver;
using quizeAppApi.Models;
using quizeAppApi.Services.Interface;

namespace quizeAppApi.Services
{
    public class UserService: IService<User>
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IOptions<UserDatabaseSettings> option)
        {
            var mongoClient = new MongoClient(
                option.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                option.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(
                option.Value.UserCollectionName);
        }

        public async Task<List<User>> GetAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User user) =>
            await _userCollection.InsertOneAsync(user);

        public async Task UpdateAsync(string id, User updatedBook) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}
