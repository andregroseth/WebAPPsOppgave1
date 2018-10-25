using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using WebAppsProsjekt1.Model;
using System.IO;
using System.Text;
using System.Web;

namespace WebAppsProsjekt1.DAL
{
	public class DBLogger
	{
		public void logChanges(DB db)
		{
			string filePath = HttpContext.Current.Server.MapPath("~/App_Data/logs/dbLog.txt");
			StringBuilder log = new StringBuilder();
			var entities = db.ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && !x.Entity.GetType().Name.Equals("Mail"));

			log.Append("---------------------------------------");
			foreach (var entry in entities)
			{
				if (entry.State.Equals(EntityState.Added)) {
					//header
					if (entry.Entity.GetType().Name.Equals("Order") || entry.Entity.GetType().Name.Equals("User") || entry.Entity.GetType().Name.Equals("Movie") || entry.Entity.GetType().Name.Equals("Mail")) {
						log.Append("\nAdded to following table: " + entry.Entity.GetType().Name);
					}
					if (!entry.Entity.GetType().Name.Equals("Orderline")) {
						log.Append("\nAdded by: " + ((BaseEntity)entry.Entity).UserAdded);
						log.Append("\nTime: " + ((BaseEntity)entry.Entity).TimeAdded);
					}
					//indent
					if (entry.Entity.GetType().Name.Equals("Orderline")) {
						log.Append("\n\t\tAdded: " + entry.Entity.GetType().Name);
					}
				}
				if (entry.State.Equals(EntityState.Modified))
				{
					log.Append("\nEdited: " + entry.Entity.GetType().Name);
					log.Append("\nEdited by: " + ((BaseEntity)entry.Entity).UserEdited);
					log.Append("\nTime: " + ((BaseEntity)entry.Entity).TimeEdited);
				}
				if (entry.State.Equals(EntityState.Deleted))
				{
					log.Append("\nDeleted: " + entry.Entity.GetType().Name);
					log.Append("\nDeleted by: " + ((BaseEntity)entry.Entity).UserDeleted);
					log.Append("\nTime: " + ((BaseEntity)entry.Entity).TimeDeleted);
				}
				if (entry.State.Equals(EntityState.Unchanged))
				{
					log.Append("\n\t\tFollowing table attributed to a changed entry: " + entry.Entity.GetType().Name);
				}
			}
			log.Append("\n---------------------------------------\n");
			db.Database.Log = tableInfo => File.AppendAllText(filePath, tableInfo);
			log.Append("\n");
			File.AppendAllText(filePath, log.ToString());
		}
	}
}
