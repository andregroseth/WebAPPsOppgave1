namespace WebAppsProsjekt1.Model
{
    public class Orderline : BaseEntity
    {
        public int Id { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }
    }
}