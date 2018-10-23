using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppsProsjekt1.Model
{
    public class VMOrder
    {
        public int Id { get; set; }

        public string Date { get; set; }

        [Display(Name = "User Id")]
        public int UserId { get; set; }
    }

    public class VMOrderline
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