namespace MissingPet.DataAccess.Entities
{
    public class ContactPersonDetails
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int AdvertId { get; set; }

        public virtual Advert Advertisement { get; set; }
    }
}
