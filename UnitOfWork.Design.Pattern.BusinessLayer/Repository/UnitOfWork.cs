using UnitOfWork.Design.Pattern.BusinessLayer.Interfaces;
using UnitOfWork.Design.Pattern.BusinessLayer.Models;

namespace UnitOfWork.Design.Pattern.BusinessLayer.Repository;
public class UnitOfWork : IUnitOfWork
{
    public IUser User {get; private set;}

    public IMovies Movies {get; private set;}
    protected readonly TremContext tremContext;

    public UnitOfWork(TremContext tremContext, IUser user, IMovies movies)
    {
        this.tremContext = tremContext;
        User = user;
        Movies = movies;
    }

    public async Task commit()
    {
        try
        {
            await tremContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

    public async Task Dispose()
    {
        await tremContext.DisposeAsync();
        GC.SuppressFinalize(true);
    }
}
