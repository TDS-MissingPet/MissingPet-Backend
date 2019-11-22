namespace MissingPet.DataAccess.Entities
{
    public class AdvertAddressDetailsEntity
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int AdvertId { get; set; }

        public virtual AdvertEntity Advertisement { get; set; }
    }
}
