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
            : base("name=Movie")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}