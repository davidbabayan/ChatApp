using System.Collections.Generic;
using System.Linq;
using ChatApp.Shared.Context;
using ChatApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace ChatApp.API.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class UsersController : ControllerBase
    {
        private UserContext userContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UsersController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            userContext = new UserContext(_hostingEnvironment.ContentRootPath + @"/Data/Users.json");
        }
        [HttpGet]
        public List<User> GetUsers()
        {
            string username = Request.Headers
                .Where(k => k.Key.ToLower() == "username").FirstOrDefault().Value;
            string password = Request.Headers
                .Where(k => k.Key.ToLower() == "password").FirstOrDefault().Value;
            User user = userContext.Users.Where(u => u.Username == username && u.Password == password).First();

            if(user != null)
            {
                List<User> usersWithoutPasswords = userContext.Users;
                foreach(var item in usersWithoutPasswords)
                    item.Password = "";
                return usersWithoutPasswords;
            }

            return new List<User>();
        }

        [HttpGet]
        public User GetUser(string userName)
        {
            string username = Request.Headers
                .Where(k => k.Key.ToLower() == "username").FirstOrDefault().Value;
            string password = Request.Headers
                .Where(k => k.Key.ToLower() == "password").FirstOrDefault().Value;
            User user = userContext.Users.Where(u => u.Username == username && u.Password == password).First();

            if(user != null)
            {
                User userWithoutPassword = userContext.Users.Where(u => u.Username == userName).FirstOrDefault();
                userWithoutPassword.Password = "";
                return userWithoutPassword;
            }

            return new User();
        }
    }
}