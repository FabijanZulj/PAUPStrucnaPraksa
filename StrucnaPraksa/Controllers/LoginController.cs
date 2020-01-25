using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StrucnaPraksa.Models;
using StrucnaPraksa.Services;

namespace StrucnaPraksa.Controllers
{
    [ApiController]
    [Route("/test")]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;
        private IUserService _userService;

        public LoginController(ILogger<LoginController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public User Authenticate(LoginModel lm)
        {
            return _userService.Authenticate(lm);
        }

        [HttpPost("register")]
        public User Register(LoginModel lm)
        {
            return _userService.Register(lm);
        }


        [HttpGet("adminTest")]
        [Authorize(Roles = Role.Admin)]
        public string adminTest()
        {
            return "YES THIS IS ADMIN";
        }
    }
}
