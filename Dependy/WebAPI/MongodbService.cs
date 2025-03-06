using MongoDB.Driver;
using WebAPI.Config;

namespace WebAPI
{
    public class MongodbService
    {
        private readonly IMongoDatabase _database;

        public MongodbService(MongoDbConfig config, IMongoClient client)
        {
            _database = client.GetDatabase(config.DBname);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}