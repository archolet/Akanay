using Akanay.Core.Entities.Models.CustomUser;
using Akanay.Core.Repository.EntityFramework;
using Akanay.Repository.Interfaces.CustomUser;
using Akanay.Repository.Models.EntityFramework.Contexts;

namespace Akanay.Repository.Models.EntityFramework.CustomUser
{
    public class EfUserRepository : EfEntitiyRepository<User, DatabaseContext>, IUserRepository
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new DatabaseContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
