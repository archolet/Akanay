using Akanay.Core.Entities.Models.CustomUser;
using Akanay.Repository.Interfaces.CustomUser;
using Akanay.Service.Interfaces.CustomUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Service.Models.CustomUser
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
           _userRepository.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
            
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }
    }
}
