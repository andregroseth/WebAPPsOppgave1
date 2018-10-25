using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Model
{
    public class Order : BaseEntity
	{
        public int Id { get; set; }

        public string Date { get; set; }
        public virtual User User { get; set; }
        public virtual List<Orderline> Orderline { get; set; }
    }
}