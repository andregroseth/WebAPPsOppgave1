using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Userlvl { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }
        public virtual Mail Mail { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}