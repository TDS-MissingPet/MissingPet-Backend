namespace MissingPet.DataAccess.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int AdvertId { get; set; }

        public virtual AdvertEntity Advertisements { get; set; }
    }
}
