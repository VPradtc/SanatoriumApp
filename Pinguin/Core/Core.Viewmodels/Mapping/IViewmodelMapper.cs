
namespace Core.Viewmodels.Mapping
{
    public interface IViewmodelMapper<in TEntity,out TViewmodel>
    {
        TViewmodel ToViewmodel(TEntity entity);
    }
}
