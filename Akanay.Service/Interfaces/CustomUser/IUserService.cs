using Akanay.Core.Entities.Models.CustomUser;

namespace Akanay.Service.Interfaces.CustomUser
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

    }
}
