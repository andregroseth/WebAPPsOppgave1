using System.Collections.Generic;

namespace WebAppsProsjekt1.Model
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public int Userlevel { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }
        public virtual Mail Mail { get; set; }
        public virtual List<Order> Order { get; set; }
    }
}