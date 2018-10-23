namespace WebAppsProsjekt1.Model
{
    public class Orderline
    {
        public int Id { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }
    }
}