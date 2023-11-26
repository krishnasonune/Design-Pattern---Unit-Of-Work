using UnitOfWork.Design.Pattern.BusinessLayer.Interfaces;
using UnitOfWork.Design.Pattern.BusinessLayer.Models;

namespace UnitOfWork.Design.Pattern.BusinessLayer.Repository;
public class UserRepository : GenericRepository<User>, IUser
{
    public UserRepository(TremContext tremContext) : base(tremContext)
    {
        
    }
}
