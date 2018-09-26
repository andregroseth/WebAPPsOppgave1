﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppsProsjekt1.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<Orderline> Orderline { get; set; }
    }
}