
namespace Core.Viewmodels.Mapping
{
    public interface IMapper<TEntity, TViewmodel> : IEntityMapper<TEntity, TViewmodel> , IViewmodelMapper<TEntity, TViewmodel>
    {

    }
}
