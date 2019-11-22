namespace MissingPet.DataAccess.Entities
{
    public class AdvertImageEntity
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public int AdvertId { get; set; }

        public virtual AdvertEntity Advertisement { get; set; }
    }
}
