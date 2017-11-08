using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IntegrationProjectNMGM.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Password { get; set; }
    }

    public class UsersDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}