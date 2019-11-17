namespace MissingPet.DataAccess.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int AdvertId { get; set; }

        public virtual Advert Advertisements { get; set; }
    }
}
