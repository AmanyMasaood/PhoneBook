using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Informatic.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Informatic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        PhoneBookDBContext context ;
        public LogInController (PhoneBookDBContext _context)
        {
            context = _context;

        }

        // GET api/<controller>
        [HttpPost]
        public bool Post(string Name,string Password)
        {
            List<User> list = (from c in context.User
                               where c.Name == Name && c.Password == Password
                               select c).ToList();
            if (list.Count > 0)
                return true;
            else
                return false;
        }

        // POST api/<controller>
        [HttpPost]
        [ActionName("AddUser")]
        public void Post(User user)
        {
            if (user != null)
            {
                context.User.Add(user);
                context.SaveChangesAsync();
            }
        }

        
    }
}
