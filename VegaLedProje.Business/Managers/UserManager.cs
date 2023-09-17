using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaLedProje.Business.Services;
using VegaLedProje.Business.Types;
using VegaLedProje.Data.Dto;
using VegaLedProje.Data.Entities;
using VegaLedProje.Data.Repositories;

namespace VegaLedProje.Business.Managers
{
    public class UserManager : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;
        private readonly IDataProtector _dataProtector;
        public UserManager(IRepository<UserEntity> userRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userRepository = userRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }
     
        public ServiceMessage AddUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public UserEntity Login(string username, string password)
        {
            var user = _userRepository.Get(x => x.UserName == username);
            if (user is null)
            {
                return null;
            }

            var userPassword = _userRepository.Get(x => x.Password == password);
            if (userPassword is null)
            {
                return null;
            }
            return user;
        }
    }
}
