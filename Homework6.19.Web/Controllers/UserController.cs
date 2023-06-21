using Homework6._19.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Homework6._19.Web.ViewModels;

namespace Homework6._19.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly string _connectionString;
        public UserController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpPost]
        [Route("adduser")]
        public void AddUser(SignupViewModel user)
        {
            var ur = new UserRepository(_connectionString);
            ur.AddUser(user, user.Password);
        }

        [HttpPost]
        [Route("login")]
        public User Login(LoginViewModel loginViewModel)
        {
            var ur = new UserRepository(_connectionString);
            var user = ur.Login(loginViewModel.Email, loginViewModel.Password);
            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim("user", loginViewModel.Email)
            };
            HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(claims, "Cookies", "user", "role"))).Wait();
            return user;
        }
        [HttpGet]
        [Route("getcurrentuser")]
        public User GetCurrentUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            var ur = new UserRepository(_connectionString);
            return ur.GetByEmail(User.Identity.Name);
        }

        [Authorize]
        [HttpPost]
        [Route("logout")]
        public void Logout()
        {
            HttpContext.SignOutAsync().Wait();
        }
    }
}
