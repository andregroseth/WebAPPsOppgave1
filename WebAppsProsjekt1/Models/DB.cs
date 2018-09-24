using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebAppsProsjekt1.Models
{
    public class DB : DbContext
    {
        public DB()
            : base("name=Customer")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Customer> Customer { get; set; }
        
    }
}