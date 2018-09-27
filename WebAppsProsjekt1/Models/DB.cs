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
            : base("name=MovieMonster")
        {
            Database.CreateIfNotExists();
            //Database.SetInitializer(new DbInit());
        }
        public virtual DbSet<User> User { get; set; }
        
        public virtual DbSet<Movie> Movie { get; set; }

        public virtual  DbSet<Order> Order { get; set; }

        public virtual DbSet<Orderline> Orderline { get; set; }

        public virtual DbSet<Mail> Mail { get; set; }
    }


    
}