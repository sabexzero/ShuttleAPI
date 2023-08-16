using ShuttleApi.ShuttleMicroservice.Models;

namespace ShuttleApi.ShuttleMicroservice.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Delete(Guid id);
        Task Save();
        Task Update(TEntity entity);
    }
}
