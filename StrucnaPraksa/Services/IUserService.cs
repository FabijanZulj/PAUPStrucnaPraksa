using StrucnaPraksa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Services
{
    public interface IUserService
    {
        User Authenticate(LoginModel lm);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Register(LoginModel lm);
    }
}
