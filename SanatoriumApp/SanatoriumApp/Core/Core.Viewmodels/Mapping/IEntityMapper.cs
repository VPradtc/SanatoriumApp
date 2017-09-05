using System;

namespace Core.Viewmodels.Mapping
{
    public interface IEntityMapper<out TEntity,in TViewmodel>
    {
        TEntity ToEntity(TViewmodel viewmodel);
    }
}
