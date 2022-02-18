using ReportService.DataAccess.Core.Interfaces;
using ReportService.Entities.Base;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace ReportService.DataAccess.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T,string> where T : BaseEntity
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<T> _dbCollection;

        protected BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<T>(typeof(T).Name);
        }



        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbCollection.Find<T>(T => true).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbCollection.Find<T>(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(string id)
        {
            return await _dbCollection.Find<T>(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(T obj)
        {
            await _dbCollection.InsertOneAsync(obj);
        }

        public async Task UpdateAsync(T obj)
        {
            await _dbCollection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.Id), obj);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            await _dbCollection.DeleteOneAsync(predicate);
        }

        public async Task DeleteAsync(string id)
        {
            await _dbCollection.DeleteOneAsync(m => m.Id == id);
        }
    }
}
