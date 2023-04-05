using Akanay.Core.Entities.Models.CustomUser;
using Akanay.Core.Utilities.Results.Interfaces;
using Akanay.Core.Utilities.Security.Jwt;
using Akanay.Entities.Dtos.CustomUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Service.Interfaces
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);




    }
}
