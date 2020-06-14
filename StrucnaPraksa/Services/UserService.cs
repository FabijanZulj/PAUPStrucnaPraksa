using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StrucnaPraksa.Helpers;
using StrucnaPraksa.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StrucnaPraksa.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _usersContext;

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, AppDbContext context)
        {
            _usersContext = context;
            _appSettings = appSettings.Value;
        }
        public User Authenticate(LoginModel login)
        {
            var pwEncrypted = PasswordEncrypt.Encrypt(login.Password);
            System.Diagnostics.Debug.WriteLine("pwencry: --------" + pwEncrypted);
            var user = _usersContext.Users.SingleOrDefault(x => x.Username == login.Username && x.Password == pwEncrypted);
            // return null if user not found
            System.Diagnostics.Debug.WriteLine("user: --------" + user);
            if (user == null)
                throw new ErrorDetails(401, "Pogresno korisnicko ime ili lozinka");

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user.WithoutPassword();
        }

        public IEnumerable<User> GetAll()
        {
            return _usersContext.Users.WithoutPasswords();
        }

        public User Register(RegisterModel lm)
        {
            var user = _usersContext.Users.SingleOrDefault(x => x.Username == lm.Username);
            if (user != null)
                throw new ErrorDetails(401, "Korisnicko ime se vec koristi");

            var registeredUser = new User();
            registeredUser.Role = Role.User;
            registeredUser.Username = lm.Username;
            registeredUser.Password = PasswordEncrypt.Encrypt(lm.Password);
            registeredUser.Ime = lm.Ime;
            registeredUser.Prezime = lm.Prezime;

            _usersContext.Users.Add(registeredUser);
            _usersContext.SaveChanges();
            return registeredUser.WithoutPassword();
        }

        public User GetById(int id)
        {
            var user = _usersContext.Users.FirstOrDefault(x => x.Id == id);
            return user.WithoutPassword();
        }
    }
}
