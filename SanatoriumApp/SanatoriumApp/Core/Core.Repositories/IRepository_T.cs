using System;
using Core.Domain;

namespace Core.Repositories
{
    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity: BaseEntity
    {
    }
}
