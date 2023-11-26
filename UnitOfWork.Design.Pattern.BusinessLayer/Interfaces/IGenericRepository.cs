namespace UnitOfWork.Design.Pattern.BusinessLayer.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllEntity();
    Task<T> GetEntityById(int entityId);
    Task<bool> AddEntity(T entity);
    bool UpdateEntity(T entity);
    bool RemoveEntity(T entity);
}
