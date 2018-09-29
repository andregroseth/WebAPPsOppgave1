using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppsProsjekt1.Models
{
    public class HelperTable
    {
        //domain model and view model for the User and Zipcode table

        public int Id { get; set; }
        public int Userlvl { get; set; }

        [Required(ErrorMessage = "Fill in your E-mail address")]
        [Remote("CheckEmail", "User", ErrorMessage = "Email Address already in use")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Confirm Email")]
        [Required(ErrorMessage = "Confirm email address")]
        [NotMapped]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Email", ErrorMessage = "Email address does not match")]
        public string ConfirmEmail { get; set; }

        [Display(Name="First Name")]
        [Required(ErrorMessage = "Fill in your name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Fill in your surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Fill in your password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage ="Confirm Password")]
        [NotMapped]
        [System.ComponentModel.DataAnnotations.CompareAttribute("Password",ErrorMessage="Password does not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Fill in your address")]
        public string Address { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Fill in your zipcode")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Invalid 4 digit Zipcode")]
        public string ZipCode { get; set; }
        public string Area { get; set; }
    }

}