namespace UnitOfWork.Design.Pattern.BusinessLayer.Interfaces;
public interface IUnitOfWork
{
    IUser User {get;}
    IMovies Movies {get;}
    Task commit();
    Task Dispose();
}
