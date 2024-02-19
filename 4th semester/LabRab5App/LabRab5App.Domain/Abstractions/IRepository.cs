
using LabRab5App.Domain.Entities;
using System.Linq.Expressions;

namespace LabRab5App.Domain.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, 
            params Expression<Func<T, object>>[]? includesProperties);
        Task<IReadOnlyList<T>> GetAllValuesAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> filter, 
            CancellationToken cancellationToken = default, 
            params Expression<Func<T, object>>[]? includesProperties);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    }
}
