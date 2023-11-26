using Microsoft.EntityFrameworkCore;
using UnitOfWork.Design.Pattern.BusinessLayer.Interfaces;
using UnitOfWork.Design.Pattern.BusinessLayer.Models;

namespace UnitOfWork.Design.Pattern.BusinessLayer.Repository;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DbSet<T> dbSet;
    public GenericRepository(TremContext tremContext)
    {
        dbSet = tremContext.Set<T>();
    }
    public async Task<bool> AddEntity(T entity)
    {
        try
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            return false;
        }
    }

    public async Task<List<T>> GetAllEntity()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<T> GetEntityById(int entityId)
    {
        return await dbSet.FindAsync(entityId);
    }

    public bool RemoveEntity(T entity)
    {
        try
        {
            dbSet.Remove(entity);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool UpdateEntity(T entity)
    {
        try
        {
            dbSet.Update(entity);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
