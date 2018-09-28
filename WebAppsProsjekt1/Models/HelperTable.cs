using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class HelperTable
    {
        //domain model and view model for the User and Zipcode table

        public int Id { get; set; }
        public int Userlvl { get; set; }

        [Required(ErrorMessage = "Fill in your E-mail address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fill in your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fill in your surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Fill in your desired password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Fill in your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Fill in your zipcode")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Invalid 4 digit Zipcode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Fill in your area")]
        public string Area { get; set; }

    }

}