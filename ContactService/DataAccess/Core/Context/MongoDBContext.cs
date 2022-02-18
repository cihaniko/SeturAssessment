using ContactService.DataAccess.Core.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ContactService.DataAccess.Core.Context
{
    public class MongoDBContext : IMongoDBContext
    {

        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<DatabaseSettings> dbOptions)
        {
            var settings = dbOptions.Value;
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _database;

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            throw new NotImplementedException();
        }
    }
}
