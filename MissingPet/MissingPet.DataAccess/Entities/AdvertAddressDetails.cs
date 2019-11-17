namespace MissingPet.DataAccess.Entities
{
    public class AdvertAddressDetails
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int AdvertId { get; set; }

        public virtual Advert Advertisement { get; set; }
    }
}
