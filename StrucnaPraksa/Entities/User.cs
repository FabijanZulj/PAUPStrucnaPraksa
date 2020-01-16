using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Models
{
    public class User
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private Role[] roles { get; set; }
    }
}
