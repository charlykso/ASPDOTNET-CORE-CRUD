using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using blog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using blog.DataAccess;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private BlogContext _blogContext;

        public LoginController(IConfiguration configuration, BlogContext blogContext)
        {
            _configuration = configuration;
            _blogContext = blogContext;
        }

        [AllowAnonymous]
        [HttpPost]
        // public IActionResult Login([FromBody] AdminLogin adminLogin)
        // {
            // var user = Authenticate(adminLogin);

            // if (user != null)
            // {
            //     var token = Generate(user);
            //     return Ok(token);
            // }
            // return NotFound("user not found");
        // }

        private string Generate(AdminModel admin)
        {
            throw new NotImplementedException();
        }

        // private AdminModel Authenticate(AdminLogin adminLogin)
        // {
        //     var currentUser = UserConstants.Users.firstOrDefault(o => o.email.ToLower() ==
        //     adminLogin.ToLower() && o.password == adminLogin.password);
        // }
    }
}