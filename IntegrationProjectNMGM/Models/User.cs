using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace IntegrationProjectNMGM.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Manager { get; set; }
    }
}