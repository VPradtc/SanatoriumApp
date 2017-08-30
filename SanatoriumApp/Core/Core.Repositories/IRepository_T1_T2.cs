using System;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity: BaseEntity<TKey>
    {
        Task<bool> UpdateAsync(TEntity entity);
        Task<TKey> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(TKey id);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}
