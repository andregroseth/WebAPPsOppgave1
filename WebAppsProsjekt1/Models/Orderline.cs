using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class Orderline
    {
        public int Id { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }
    }
}