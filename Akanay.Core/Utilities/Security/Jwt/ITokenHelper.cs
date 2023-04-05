using Akanay.Core.Entities.Models.CustomUser;

namespace Akanay.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);

    }
}
