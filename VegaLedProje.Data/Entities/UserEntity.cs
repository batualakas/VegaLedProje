
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaLedProje.Data.Enums;

namespace VegaLedProje.Data.Entities
{
    public class UserEntity : BaseEntity
    {
       
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}
