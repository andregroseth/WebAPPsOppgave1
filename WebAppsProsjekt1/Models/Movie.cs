using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAppsProsjekt1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Category { get; set; }
        public int Value { get; set; }
        public String ImagePath { get; set; }
    }
}