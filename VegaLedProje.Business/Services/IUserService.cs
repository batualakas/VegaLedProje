using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaLedProje.Business.Types;
using VegaLedProje.Data.Dto;
using VegaLedProje.Data.Entities;

namespace VegaLedProje.Business.Services
{
    public interface IUserService
    {
        ServiceMessage AddUser(UserDto user);
        UserEntity Login(string username, string password);
    }
}
