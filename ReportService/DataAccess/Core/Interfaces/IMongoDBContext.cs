using MongoDB.Driver;

namespace ReportService.DataAccess.Core.Interfaces
{
    public interface IMongoDBContext
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }

        IMongoCollection<T> GetCollection<T>(string name);
    }
}