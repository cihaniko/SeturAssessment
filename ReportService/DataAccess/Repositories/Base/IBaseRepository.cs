using ReportService.Entities.Base;
using System.Linq.Expressions;

namespace ReportService.DataAccess.Repositories.Base
{
    public interface IBaseRepository<T,S> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(S id);

        Task AddAsync(T obj);

        Task UpdateAsync(T obj);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        Task DeleteAsync(S id);
    }
}
