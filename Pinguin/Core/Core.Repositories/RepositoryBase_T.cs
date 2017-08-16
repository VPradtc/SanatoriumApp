using System;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public abstract Task<int> CreateAsync(TEntity entity);

        public abstract Task<bool> DeleteAsync(int id);

        public abstract Task<TEntity> GetByIdAsync(int id);

        public abstract Task<bool> UpdateAsync(TEntity entity);
    }
}
