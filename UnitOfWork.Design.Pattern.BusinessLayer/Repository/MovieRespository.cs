using UnitOfWork.Design.Pattern.BusinessLayer.Interfaces;
using UnitOfWork.Design.Pattern.BusinessLayer.Models;

namespace UnitOfWork.Design.Pattern.BusinessLayer.Repository;
public class MovieRepository : GenericRepository<Movie>, IMovies
{
    public MovieRepository(TremContext tremContext) : base(tremContext)
    {
    }
}
