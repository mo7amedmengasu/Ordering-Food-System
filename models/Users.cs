using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Project.models
{
   public class Users
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserAddress { get; set; }
        public string UserRole { get; set; }
        public string UserPassword { get; set; }
    }
}
