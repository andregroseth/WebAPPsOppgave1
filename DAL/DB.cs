using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebAppsProsjekt1.Model;

namespace WebAppsProsjekt1.DAL
{ 
    public class DB : DbContext
    {
        public DB() : base("name=MovieMonster")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DbInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

		public void addExtrasToEntries(DbChangeTracker changeTracker)
		{
			var entities = changeTracker.Entries().Where(x => x.Entity is BaseEntity);
			string username = !string.IsNullOrEmpty(HttpContext.Current?.Session["Email"]?.ToString())
				? HttpContext.Current?.Session["Email"]?.ToString()
				: "Anonymous";

			foreach (var entity in entities)
			{
				if (entity.State == EntityState.Added)
				{
					((BaseEntity)entity.Entity).TimeAdded = DateTime.UtcNow;
					((BaseEntity)entity.Entity).UserAdded = username;
				} else if (entity.State == EntityState.Modified)
				{
					((BaseEntity)entity.Entity).TimeEdited = DateTime.UtcNow;
					((BaseEntity)entity.Entity).UserEdited = username;
				} else if (entity.State == EntityState.Deleted) {
					((BaseEntity)entity.Entity).TimeDeleted = DateTime.UtcNow;
					((BaseEntity)entity.Entity).UserDeleted = username;
				}
			}
		}

		public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual  DbSet<Order> Order { get; set; }
        public virtual DbSet<Orderline> Orderline { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
    }
}