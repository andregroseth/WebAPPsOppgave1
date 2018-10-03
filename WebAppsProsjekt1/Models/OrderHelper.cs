﻿using System;
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

    public class OrderlineHelper
    {

        public int Id { get; set; }

        [Display(Name ="Movie Id")]
        public int MovieId { get; set; }
        public String Title { get; set; }
        public String Category { get; set; }
        public int Cost { get; set; }
        public string ImagePath { get; set; }
    }
}