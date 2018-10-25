using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppsProsjekt1.Model
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill in Movie Tittle")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Fill in Movie Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Fill in your Cost")]
        //[RegularExpression(@"[0-9]", ErrorMessage = "Invalid Cost")]
        public int Cost { get; set; }
        public string ImagePath { get; set; }
        public string MovieSrc { get; set; }
    }
}