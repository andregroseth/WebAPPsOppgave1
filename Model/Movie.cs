using System;

namespace WebAppsProsjekt1.Model
{
    public class Movie : BaseEntity
    {
        public int Id { get; set; }

        public String Title { get; set; }
        public String Category { get; set; }
        public int Cost { get; set; }
        public string ImagePath { get; set; }
        public string MovieSrc { get; set; }
    }
}