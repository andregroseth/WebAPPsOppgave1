using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppsProsjekt1.Model
{
	public class BaseEntity
	{
		public DateTime? TimeAdded { get; set; }
		public string UserAdded { get; set; }
		public DateTime? TimeEdited { get; set; }
		public string UserEdited { get; set; }
		public DateTime? TimeDeleted { get; set; }
		public string UserDeleted { get; set; }
	}
}
