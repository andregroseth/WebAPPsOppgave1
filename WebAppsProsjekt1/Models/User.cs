using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppsProsjekt1.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Userlvl { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }
        public virtual Mail Mail { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}