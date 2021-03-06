using ReportService.Entities.Abstract;
using System.Linq.Expressions;

namespace ReportService.DataAccess.Repositories.Abstract
{

    public interface IBaseRepository<T, in TKey> where T : class, IBaseEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(TKey id);
        Task<T> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(TKey id, T entity);
        Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteAsync(TKey id);
        Task<T> DeleteAsync(Expression<Func<T, bool>> filter);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> filter);
        Task<bool> IsExistAsync(TKey id);
    }
}
