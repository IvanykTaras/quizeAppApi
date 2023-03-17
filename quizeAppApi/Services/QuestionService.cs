using Microsoft.Extensions.Options;
using MongoDB.Driver;
using quizeAppApi.Models;

namespace quizeAppApi.Services
{
    public class QuestionService
    {
        private readonly IMongoCollection<Question> _questionCollection;

        public QuestionService(IOptions<QuizeDatabaseSettings> option)
        {

            var mongoClient =
                new MongoClient(option.Value.ConnectionString);

            var mongoDatabase =
                mongoClient.GetDatabase(option.Value.DatabaseName);

            _questionCollection =
                mongoDatabase.GetCollection<Question>(option.Value.QuestionCollectionName);

        }

        //================
        //Question methods
        //================

        public async Task<List<Question>> GetAsync()
            => await _questionCollection.Find(_ => true).ToListAsync();
        public async Task<Question?> GetAsync(string id)
            => await _questionCollection.Find(e => e.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Question item)
            => await _questionCollection.InsertOneAsync(item);
        public async Task UpdateAsync(string id, Question item)
            => await _questionCollection.ReplaceOneAsync(e => e.Id == id, item);
        public async Task RemoveAsync(string id)
            => await _questionCollection.DeleteOneAsync(e => e.Id == id);

    }
}
