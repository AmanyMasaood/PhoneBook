using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Informatic.Models
{
    public class PhoneBookDBContext:DbContext
    {
        public PhoneBookDBContext(DbContextOptions<PhoneBookDBContext> options)
            :base(options)
        { }

        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<User> User { get; set; }
    }
}
