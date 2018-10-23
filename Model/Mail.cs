using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppsProsjekt1.Model
{

    public class Mail
    {
        [Key]
        public string ZipCode { get; set; }

        public string Area { get; set; }
        public virtual List<User> User { get; set; }
    }
}