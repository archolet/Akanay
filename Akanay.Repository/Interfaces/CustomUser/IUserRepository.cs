using Akanay.Core.Entities;
using Akanay.Core.Entities.Models.CustomUser;
using Akanay.Core.Repository;

namespace Akanay.Repository.Interfaces.CustomUser
{
    public interface IUserRepository:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        //void Add(User user);
        //User GetByMail(string email);
    }
}
