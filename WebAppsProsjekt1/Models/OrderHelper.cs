using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class OrderHelper
    {
        
        public int Id { get; set; }

        public string Date { get; set; }

        [Display(Name = "User Id")]
        public int UserId { get; set; }

    }
}