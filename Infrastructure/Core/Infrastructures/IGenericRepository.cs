using Infrastructure.Models.EntitiesBase;
namespace Infrastructure.Core.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int? id);
        IEnumerable<TEntity> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
